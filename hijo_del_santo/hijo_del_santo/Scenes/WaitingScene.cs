using hijo_del_santo.Assets;
using Objects.Events;
using System.Drawing;

namespace hijo_del_santo.Scenes
{
    class WaitingScene : IScene
    {
        private string text;
        private int wait_time;
        private int max_wait_time;
        private int dot_count;
        private int max_dot_count;
        private TextField waiting_text;
        private RectButton cancel;
        private int polling_wait_time = 0;
        private bool first = true;

        public WaitingScene()
        {
            text = "Waiting for an opponent";
            wait_time = 0;
            max_wait_time = 20;
            dot_count = 0;
            max_dot_count = 3;
            waiting_text = new TextField(text, 100,
                           new Point(Screen.width / 2, Screen.height / 2),
                           Color.Black);
            cancel = new RectButton(Color.White, Color.DarkRed,
                     new PointF(Screen.width / 2.0f, Screen.height * 7.0f / 8.0f),
                     new SizeF(400.0f, 100.0f),
                     "Cancel", 60);
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            if(cancel.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.TownHall);
                first = true;
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void Render()
        {
            if(first)
            {
                StartMatchmaking();
                first = false;
            }

            if(polling_wait_time <= 0)
            {
                PollingForMatchmaking();
                polling_wait_time = 60;
            }

            if(wait_time >= max_wait_time)
            {
                if(dot_count >= max_dot_count)
                {
                    dot_count = 0;
                    waiting_text.UpdateText(text);
                }

                wait_time = 0;
                waiting_text.text += ".";
                ++dot_count;
            }
            ++wait_time;
            --polling_wait_time;

            waiting_text.Render();
            cancel.Render();
        }

        public void PollingForMatchmaking()
        {
            var ev = Screen.Server.Poll(Screen.sessionId).Result;
            if(ev.Result.type == EventType.Matchfound)
            {
                var matchEvent = (MatchFoundEvent)ev.Result;
                Screen.room = matchEvent.Room;
                Screen.scene.SetScene(SceneID.Fight);  
                first = true;
            }
        }

        public async void StartMatchmaking()
        {
            if(Screen.IsPvpMatchmaking)
            {
                await Screen.Server.StartPvpMatchmaking(Screen.sessionId);
            }
            else
            {
                await Screen.Server.StartPveMatchmaking(Screen.chosen_opponent, Screen.sessionId);
            }
        }


    }
}
