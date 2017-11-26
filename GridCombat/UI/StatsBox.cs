namespace GridCombat.UI
{
    #region Usings

    using GridCombat.Actors;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    #endregion

    class StatsBox : BaseInstance
    {
        #region Constants

        private const int padding = 10;

        #endregion

        #region Methods

        public static void Draw(SpriteBatch spriteBatch, Hero hero)
        {
            string stats = String.Empty;

            stats += "Team: " + hero.Team + "\n";
            stats += "Health: " + hero.CurrentHealth + "/" + hero.MaxHealth + "\n";
            stats += "Energy: " + hero.CurrentEnergy + "/" + hero.MaxEnergy;

            int x = (hero.PosX + 1) * Tile.diameter;
            int y = hero.PosY * Tile.diameter;

            Vector2 boxDimensions = Textures.SpriteFont.MeasureString(stats) + new Vector2(padding * 2, padding * 2);
            Rectangle destinationRect = new Rectangle(x, y, (int)boxDimensions.X, (int)boxDimensions.Y);

            spriteBatch.Draw(Textures.StatsBox, destinationRect, Color.White);

            spriteBatch.DrawString(Textures.SpriteFont, stats, new Vector2(x + padding, y + padding), Color.Black);
        }

        #endregion
    }
}
