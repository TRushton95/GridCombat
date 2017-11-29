namespace GridCombat
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.UI;
    using GridCombat.UI.Components;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    partial class Board
    {
        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Tile> row in Tiles)
            {
                foreach (Tile tile in row)
                {
                    tile.Draw(spriteBatch, tile.PosX * Tile.diameter, tile.PosY * Tile.diameter);
                }
            }

            if (HighlightedTile != null)
            {
                spriteBatch.Draw(
                    Textures.TileHighlight,
                    new Vector2((HighlightedTile.PosX * Tile.diameter) + HighlightBorderWidth, (HighlightedTile.PosY * Tile.diameter) + HighlightBorderWidth),
                    Color.White);
            }

            int offset = (Tile.diameter / 2) - (Hero.diameter / 2);

            foreach (Hero hero in Heroes)
            {
                hero.Draw(spriteBatch, (hero.PosX * Tile.diameter) + offset, (hero.PosY * Tile.diameter) + offset);
            }

            if (SelectedHero != null)
            {
                spriteBatch.Draw(
                    Textures.SelectedHero,
                    new Vector2((SelectedHero.PosX * Tile.diameter) + offset - HighlightBorderWidth, (SelectedHero.PosY * Tile.diameter) + offset - HighlightBorderWidth),
                    Color.White);
                StatsBox.DrawHeroStats(spriteBatch, SelectedHero, true);
            }

            if (HighlightedHero != null && HighlightedHero != SelectedHero)
            {
                StatsBox.DrawHeroStats(spriteBatch, HighlightedHero, false);
            }

            if (SelectedHero != null)
            {
                Spellbar.Draw(spriteBatch, SelectedHero);
            }

            if (HighlightedAbility != null)
            {
                StatsBox.DrawAbilityStats(spriteBatch, HighlightedAbility);
            }

            if (SelectedAbility != null && HighlightedTile != null)
            {
                Texture2D filter;
                bool validTarget = SelectedAbility.ValidateTarget(HighlightedTile);

                if (validTarget)
                {
                    filter = Textures.GreenFilter;
                }
                else
                {
                    filter = Textures.RedFilter;
                }

                int posX = (HighlightedTile.PosX * Tile.diameter) + HighlightBorderWidth;
                int posY = (HighlightedTile.PosY * Tile.diameter) + HighlightBorderWidth;

                spriteBatch.Draw(filter, new Vector2(posX, posY), new Color(Color.White, 0.1f));
            }

            #endregion
        }
    }
}
