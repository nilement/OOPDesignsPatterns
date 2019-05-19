using hijo_del_santo.Scenes;

namespace hijo_del_santo.Mediator
{
    class InteractionMediator : IInteractionMediator
    {
        private IColleague PvpWarning;
        private IColleague PvpButton;
        private IColleague ShopButton;
        private IColleague ShopWarning;

        public InteractionMediator(IColleague pvpWarning, IColleague pvpButton, IColleague shopButton, IColleague shopWarning)
        {
            PvpWarning = pvpWarning;
            PvpButton = pvpButton;
            ShopWarning = shopWarning;
            ShopButton = shopButton;
        }

        public void TryMatchmaking()
        {
            if (Screen.character.Level >= 5)
            {
                Screen.scene.SetScene(SceneID.Waiting);
            }
            else
            {
                PvpWarning.Enable();
                PvpButton.Disable();
            } 
        }

        public void TryEnterShop()
        {
            if (Screen.character.Gold >= 10)
            {
                Screen.scene.SetScene(SceneID.Shop);
            }
            else
            {
                ShopWarning.Enable();
                ShopButton.Disable();
            }
        }

        public void CloseWarning()
        {
            PvpWarning.Disable();
            ShopWarning.Disable();
            PvpButton.Enable();
            ShopButton.Enable();
        }
    }
}
