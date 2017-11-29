namespace GridCombat.UI.States
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using GridCombat.UI.Components;
    using Microsoft.Xna.Framework.Input;

    #endregion

    class UnselectedState : BaseInstance, IUIState
    {
        #region Methods

        public IUIState HandleInput(MouseState mouseState, MouseState prevMouseState)
        {
            Tile hoveredTile = Board.GetTileAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);

            Hero hoveredHero = hoveredTile != null ? hoveredTile.Occuptant : null;

            // Hover tile
            if (hoveredTile != null)
            {
                if (Board.HighlightedTile != hoveredTile)
                {
                    Board.HighlightedTile = hoveredTile;
                }
            }
            else
            {
                Board.HighlightedTile = null;
            }

            //Hover or select hero
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

            if (mouseState.Position.X > EndTurnBox.PosX && mouseState.Position.X < EndTurnBox.PosX + EndTurnBox.Width &&
                mouseState.Position.Y > EndTurnBox.PosY && mouseState.Position.Y < EndTurnBox.PosY + EndTurnBox.Height)
            {
                //End turn logic here
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
