namespace GridCombat.UI.States
{
    using GridCombat.Abilities;
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
            Tile hoveredTile = Board.GetTileAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);

            Hero hoveredHero = hoveredTile != null ? hoveredTile.Occuptant : null;

            Ability hoveredAbility = Board.GetAbilityIconAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);


            // Hover tile
            if (hoveredTile != null)
            {
                if (Board.HighlightedTile != hoveredTile)
                {
                    Board.HighlightedTile = hoveredTile;
                }

                //Move
                if (hoveredTile.Occuptant == null)
                {
                    if (mouseState.RightButton == ButtonState.Pressed &&
                        prevMouseState.RightButton != ButtonState.Pressed)
                    {
                        Board.MoveHero(selectedHero, hoveredTile.PosX, hoveredTile.PosY);
                    }
                }
            }
            else
            {
                Board.HighlightedTile = null;
            }


            //Hover ability
            if (hoveredAbility != null)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton != ButtonState.Pressed)
                {
                    Board.SelectedAbility = hoveredAbility;
                    return new TargetingState(selectedHero, hoveredAbility);
                }

                if (hoveredAbility != Board.HighlightedAbility)
                {
                    Board.HighlightedAbility = hoveredAbility;
                }
            }
            else
            {
                Board.HighlightedAbility = null;
            }


            // Hover or Select hero
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
            // Deselect hero
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
