using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using hijo_del_santo.Assets;
using Objects;

namespace hijo_del_santo.Scenes
{
    class SelectionScene : IScene
    {
        private bool first_launch;
        private TextField title;
        private int character_count = 5;
        private RectButton[] characterButtons;
        private int current_char;
        private RectButton next;
        private RectButton new_char;
        private List<Character> characters;
        public SelectionScene()
        {
            first_launch = true;
            title = new TextField("Select your character", 50, new Point(Screen.width / 2, Screen.height / 16), Color.Black);

            characterButtons = new RectButton[5];
            characterButtons[0] = new RectButton(Color.White, Color.DarkRed, Color.Magenta,
                            new PointF(Screen.width / 2.0f, 2.0f * Screen.height / 8.0f),
                            new SizeF(300.0f, 75.0f),
                            "Character 0", 30);
            characterButtons[1] = new RectButton(Color.White, Color.DarkRed, Color.Magenta,
                            new PointF(Screen.width / 2.0f, 3.0f * Screen.height / 8.0f),
                            new SizeF(300.0f, 75.0f),
                            "Character 1", 30);
            characterButtons[2] = new RectButton(Color.White, Color.DarkRed, Color.Magenta,
                            new PointF(Screen.width / 2.0f, 4.0f * Screen.height / 8.0f),
                            new SizeF(300.0f, 75.0f),
                            "Character 2", 30);
            characterButtons[3] = new RectButton(Color.White, Color.DarkRed, Color.Magenta,
                            new PointF(Screen.width / 2.0f, 5.0f * Screen.height / 8.0f),
                            new SizeF(300.0f, 75.0f),
                            "Character 3", 30);
            characterButtons[4] = new RectButton(Color.White, Color.DarkRed, Color.Magenta,
                            new PointF(Screen.width / 2.0f, 6.0f * Screen.height / 8.0f),
                            new SizeF(300.0f, 75.0f),
                            "Character 4", 30);

            current_char = -1;

            next = new RectButton(Color.White, Color.DarkGreen,
                   new PointF(Screen.width / 2.0f, 7.0f * Screen.height / 8.0f),
                   new SizeF(200.0f, 100.0f),
                   "Next", 50);

            new_char = new RectButton(Color.White, Color.DarkBlue,
                       new PointF(6.0f * Screen.width / 8.0f, 7.0f * Screen.height / 8.0f),
                       new SizeF(500.0f, 50.0f),
                       "Create New Character", 30);
        }

        private async void Init()
        {
            first_launch = false;
            characters = (await Screen.Server.GetAccountCharacters(Screen.sessionId)).Result;
            character_count = characters.Count;
            for (var i = 0; i < characters.Count; i++)
            {
                characterButtons[i].UpdateText(characters[i].Name);
            }

            for (var i = characters.Count; i < characterButtons.Length; i++)
            {
                characterButtons[i].UpdateText("Empty");
            }
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            for(int i = 0; i < characterButtons.Length; ++i)
            {
                if(characterButtons[i].Contains(mouse.point))
                {
                    if(current_char == i)
                    {
                        current_char = -1;
                    }
                    else
                    {
                        current_char = i;
                    }
                }
            }

            if(next.Contains(mouse.point))
            {
                if(current_char >= 0 && current_char < characterButtons.Length)
                {
                    first_launch = true;
                    Screen.scene.SetScene(SceneID.TownHall);
                    if(Screen.Server.SelectCharacter(characters[current_char], Screen.sessionId).Result.Result)
                    {
                        Screen.character = characters[current_char];
                    }
                }
            }
            else if(new_char.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.Creation);
                first_launch = true;
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void Render()
        {
            if(first_launch)
            {
                Init();
            }

            if(current_char >= 0 && current_char < characterButtons.Length)
            {
                // TODO(rytis): Draw stats and image here.
            }

            title.Render();
            for(int i = 0; i < characterButtons.Length; ++i)
            {
                if(i == current_char)
                {
                    characterButtons[i].Render(true);
                }
                else
                {
                    characterButtons[i].Render(false);
                }
            }
            next.Render();
            new_char.Render();
        }
    }
}
