namespace GridCombat.UI.States
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using Microsoft.Xna.Framework.Input;
    using System;

    #endregion

    class SelectedState : BaseInstance, IUIState
    {
        #region Fields

        private Hero selectedHero;

        #endregion

        #region Constructors

        public SelectedState(Hero selectedHero)
        {
            this.selectedHero = selectedHero;
        }

        #endregion

        #region Methods

        public IUIState HandleInput(MouseState mouseState, MouseState prevMouseState)
        {
            Hero hoveredHero = Board.GetHeroAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);

            if (hoveredHero != null)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton != ButtonState.Pressed)
                {
                    return new SelectedState(hoveredHero);
                }

                if (hoveredHero != Board.HighlightedHero && hoveredHero != Board.SelectedHero)
                {
                    Board.HighlightedHero = hoveredHero;
                }
            }
            else
            {
                Board.HighlightedHero = null;

                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    return new UnselectedState();
                }
            }

            return null;
        }

        public void OnEnter()
        {
            Board.SelectedHero = selectedHero;
        }

        public void OnLeave()
        {

        }

        #endregion
    }
}
