using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using hijo_del_santo.Scenes.TemplateMethod;

namespace hijo_del_santo.Scenes
{
    enum SceneID
    {
        Landing,
        Register,
        Login,
        Selection,
        Creation,
        TownHall,
        Fight,
        Shop,
        Backpack,
        Waiting,
        PostFight,

        Count,
    }

    class SceneController
    {
        public SceneID current_id;
        private IScene current_scene;

        private LandingScene landing;
        private TemplateScene registration;
        private TemplateScene login;
        private SelectionScene selection;
        private CreationScene creation;
        private TownHallScene town_hall;
        private FightScene fight;
        private ShopScene shop;
        private BackpackScene backpack;
        private WaitingScene waiting;
        private PostFightScene post_fight;

        public SceneController()
        {
            landing = new LandingScene();
            registration = new RegistrationScene();
            login = new LoginScene();
            selection = new SelectionScene();
            creation = new CreationScene();
            town_hall = new TownHallScene();
            fight = new FightScene();
            shop = new ShopScene();
            backpack = new BackpackScene();
            waiting = new WaitingScene();
            post_fight = new PostFightScene();

            current_id = SceneID.Landing;
            current_scene = landing;
        }

        public void SetScene(SceneID id)
        {
            current_id = id;
            switch(id)
            {
                default:
                {
                    throw new Exception();
                } break;
                case SceneID.Landing:
                {
                    current_scene = landing;
                } break;
                case SceneID.Register:
                {
                    current_scene = registration;
                } break;
                case SceneID.Login:
                {
                    current_scene = login;
                } break;
                case SceneID.Selection:
                {
                    current_scene = selection;
                } break;
                case SceneID.Creation:
                {
                    current_scene = creation;
                } break;
                case SceneID.TownHall:
                {
                    current_scene = town_hall;
                } break;
                case SceneID.Fight:
                {
                    current_scene = fight;
                } break;
                case SceneID.Shop:
                {
                    current_scene = shop;
                } break;
                case SceneID.Backpack:
                {
                    current_scene = backpack;
                } break;
                case SceneID.Waiting:
                {
                    current_scene = waiting;
                } break;
                case SceneID.PostFight:
                {
                    current_scene = post_fight;
                } break;
            }
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            current_scene.HandleMouseInput(mouse);
        }

        public void HandleKeyboardInput(KeyInput key)
        {
            current_scene.HandleKeyboardInput(key);
        }

        public void Render()
        {
            current_scene.Render();
        }
    }
}
