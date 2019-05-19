using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using hijo_del_santo.Assets;
using Objects;
using Objects.Events;
using hijo_del_santo.Properties;

namespace hijo_del_santo.Scenes
{
    class FightScene : IScene
    {
        private RectButton attack;

        private Point player_name_point;
        private TextField player_name;
        private PointF player_spawn_point;
        private Entity player;

        private Point enemy_name_point;
        private TextField enemy_name;
        private PointF enemy_spawn_point;
        private Entity enemy;

        private TextField damage_received;
        private TextField damage_dealt;
        private int alpha_received;
        private int alpha_dealt;

        private bool first_render = true;
        private bool player_turn;
        private int polling_wait_time;

        private SoundPlayer fight_music_player;

        public FightScene()
        {
            attack = new RectButton(Color.White, Color.DarkRed,
                     new PointF(Screen.width / 2.0f, 7.0f * Screen.height / 8.0f),
                     new SizeF(500, 150),
                     "Attack!", 100);

            player_spawn_point = new PointF(3.0f * Screen.width / 8.0f, Screen.height / 2.0f);

            enemy_spawn_point = new PointF(5.0f * Screen.width / 8.0f, Screen.height / 2.0f);

            player_name_point = Screen.Point(3.0f / 8.0f - 0.05f, 0.25f);
            enemy_name_point = Screen.Point(5.0f / 8.0f + 0.05f, 0.25f);

            damage_received = new TextField("0", 40,
                              Screen.Point(3.0f / 8.0f - 0.15f, 0.5f), Color.Red);
            damage_dealt = new TextField("0", 40,
                           Screen.Point(5.0f / 8.0f + 0.15f, 0.5f), Color.Red);
            alpha_received = 0;
            alpha_dealt = 0;

            fight_music_player = new SoundPlayer(Resources.FightingMusic);
        }

        private void InitFight()
        {
            int myHealth, enemyHealth;
            myHealth = Screen.room.GetMyHealth(Screen.sessionId);
            string enemy_name_string = "N/A";
            if(!Screen.IsPvpMatchmaking)
            {
                enemy_name_string = Screen.room.PveOpponent.Name;
                enemyHealth = Screen.room.PveOpponent.Strength * 25;
                player_turn = true;
            }
            else
            {
                enemy_name_string = Screen.room.GetOpponentName(Screen.sessionId);
                enemyHealth = Screen.room.GetMyOpponentHealth(Screen.sessionId);
                player_turn = Screen.room.IsMyTurn(Screen.sessionId);
            }
            player = new Entity(myHealth, myHealth, player_spawn_point, false);
            enemy = new Entity(enemyHealth, enemyHealth, enemy_spawn_point, true);
            player_name = new TextField(Screen.character.Name, 30, player_name_point, Color.Black);
            enemy_name = new TextField(enemy_name_string, 30, enemy_name_point, Color.Black);

            alpha_received = 0;
            alpha_dealt = 0;
            damage_received.UpdateColor(Color.FromArgb(alpha_received, Color.Red));
            damage_dealt.UpdateColor(Color.FromArgb(alpha_dealt, Color.Red));

            fight_music_player.Play();
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            if(attack.Contains(mouse.point) && player_turn)
            {
                var http = new HttpAdapter();
                var move = new FightMoveCall {FightMove = ActionType.Attack, RoomId = Screen.room.RoomId};
                var enemyHP = http.Attack(move, Screen.sessionId).Result.Result;

                int damage = enemy.hit_points - enemyHP;
                damage_dealt.UpdateText("-" + damage);
                alpha_dealt = 255;

                player.attack = true;
                player_turn = false;
                enemy.SetHP(enemyHP);
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void PollingForCombat()
        {
            var ev = Screen.Server.Poll(Screen.sessionId).Result;
            if (ev.Result.type == EventType.CombatEvent)
            {
                var matchEvent = (CombatEvent)ev.Result;

                int damage = player.hit_points - matchEvent.Health;
                damage_received.UpdateText("-" + damage);
                alpha_received = 255;

                enemy.attack = true;
                player_turn = true;
                player.SetHP(matchEvent.Health);
            }

            if (ev.Result.type == EventType.CombatOverEvent)
            {
                Screen.combat_over_event = (CombatOverEvent)ev.Result;
                if (((CombatOverEvent) ev.Result).IsWinner)
                {
                    first_render = true;
                    fight_music_player.Stop();
                    Screen.scene.SetScene(SceneID.PostFight);
                }
                else
                {
                    player.SetHP(0);
                    enemy.attack = true;
                }
            }
        }

        public void Render()
        {
            if(first_render)
            {
                InitFight();
                first_render = false;
            }

            alpha_received = Math.Max(alpha_received - 5, 0);
            alpha_dealt = Math.Max(alpha_dealt - 5, 0);
            damage_received.UpdateColor(Color.FromArgb(alpha_received, Color.Red));
            damage_dealt.UpdateColor(Color.FromArgb(alpha_dealt, Color.Red));

            player_name.Render();
            enemy_name.Render();
            damage_received.Render();
            damage_dealt.Render();

            enemy.Render();
            player.Render();

            if(!player.attack && !enemy.attack && player_turn)
            {
                attack.Render();
            }

            if(polling_wait_time >= 60)
            {
                PollingForCombat();
                polling_wait_time = 0;
                if(player.hit_points <= 0 && !enemy.attack)
                {
                    first_render = true;
                    fight_music_player.Stop();
                    Screen.scene.SetScene(SceneID.PostFight);
                }
            }

            polling_wait_time++;
        }
    }
}
