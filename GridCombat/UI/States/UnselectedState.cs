namespace GridCombat.UI.States
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using Microsoft.Xna.Framework.Input;

    #endregion

    class UnselectedState : BaseInstance, IUIState
    {
        #region Methods

        public IUIState HandleInput(MouseState mouseState, MouseState prevMouseState)
        {
            Hero hoveredHero = Board.GetHeroAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);

            if (hoveredHero != null)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    return new SelectedState(hoveredHero);
                }

                if (hoveredHero != Board.HighlightedHero)
                {
                    Board.HighlightedHero = hoveredHero;
                }
            }
            else
            {
                Board.HighlightedHero = null;
            }

            return null;
        }

        public void OnEnter()
        {
            Board.SelectedHero = null;
        }

        public void OnLeave()
        {

        }

        #endregion
    }
}
