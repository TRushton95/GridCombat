﻿namespace GridCombat.UI.States
{
    #region Usings

    using GridCombat.Abilities;
    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using Microsoft.Xna.Framework.Input;

    #endregion

    class TargetingState : BaseInstance, IUIState
    {
        #region Fields

        public Hero selectedHero;
        public Ability selectedAbility;

        #endregion

        #region Constructors

        public TargetingState(Hero selectedHero, Ability selectedAbility)
        {
            this.selectedHero = selectedHero;
            this.selectedAbility = selectedAbility;
        }

        #endregion

        #region Methods

        public IUIState HandleInput(MouseState mouseState, MouseState prevMouseState)
        {
            Tile hoveredTile = Board.GetTileAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);

            Hero hoveredHero = hoveredTile != null ? hoveredTile.Occuptant : null;

            Ability hoveredAbility = Board.GetAbilityIconAtCanvasPosition(mouseState.Position.X, mouseState.Position.Y);


            //Deselect ability
            if (mouseState.RightButton == ButtonState.Pressed &&
                        prevMouseState.RightButton != ButtonState.Pressed)
            {
                Board.SelectedAbility = null;
                return new SelectedState(selectedHero);
            }

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


            // Validate and execute ability
            if (mouseState.LeftButton == ButtonState.Pressed &&
                prevMouseState.LeftButton != ButtonState.Pressed)
            {
                /*
                 * TO-DO
                 * 
                 * VALIDATE TARGET AND SHOW RESULT TO USER IN TOOLTIP
                 * 
                 * selectedAbility.ValidateTarget(hoveredTile);
                 * 
                 */

                if (hoveredTile != null)
                {
                    selectedAbility.Execute(hoveredTile);
                }
            }

            if (hoveredHero != Board.HighlightedHero && hoveredHero != Board.SelectedHero)
            {
                Board.HighlightedHero = hoveredHero;
            }

            return null;
        }

        public void OnEnter()
        {

        }

        public void OnLeave()
        {

        }

        #endregion
    }
}
