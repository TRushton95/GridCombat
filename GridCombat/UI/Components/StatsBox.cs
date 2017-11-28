namespace GridCombat.UI
{
    using GridCombat.Abilities;
    #region Usings

    using GridCombat.Actors;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;

    #endregion

    class StatsBox : BaseInstance
    {
        #region Constants

        private const int padding = 10;

        #endregion

        #region Methods

        public static void DrawHeroStats(SpriteBatch spriteBatch, Hero hero, bool isHeroSelected = false)
        {
            string stats = String.Empty;

            stats += "Team: " + hero.Team + "\n";
            stats += "Health: " + hero.CurrentHealth + "/" + hero.MaxHealth + "\n";
            stats += "Energy: " + hero.CurrentEnergy + "/" + hero.MaxEnergy;

            int x = (hero.PosX + 1) * Tile.diameter;
            int y = hero.PosY * Tile.diameter;

            Vector2 boxDimensions = Textures.SpriteFont.MeasureString(stats) + new Vector2(padding * 2, padding * 2);

            Point statsBoxPos;
            float transparency;

            if (isHeroSelected)
            {
                statsBoxPos = new Point(x, y);
                transparency = 1f;
            }
            else
            {
                statsBoxPos = Mouse.GetState().Position;
                transparency = 0.8f;
            }

            Rectangle destinationRect = new Rectangle(statsBoxPos.X, statsBoxPos.Y, (int)boxDimensions.X, (int)boxDimensions.Y);

            spriteBatch.Draw(Textures.StatsBox, destinationRect, new Color(Color.White, transparency));

            spriteBatch.DrawString(Textures.SpriteFont, stats, new Vector2(statsBoxPos.X + padding, statsBoxPos.Y + padding), new Color(Color.Black, transparency));
        }



        public static void DrawAbilityStats(SpriteBatch spriteBatch, Ability ability)
        {
            string description = ability.GetProfile();

            Vector2 boxDimensions = Textures.SpriteFont.MeasureString(description) + new Vector2(padding * 2, padding * 2);

            Point statsBoxPos = Mouse.GetState().Position;

            Rectangle destinationRect = new Rectangle(statsBoxPos.X, statsBoxPos.Y, (int)boxDimensions.X, (int)boxDimensions.Y);

            spriteBatch.Draw(Textures.StatsBox, destinationRect, Color.White);

            spriteBatch.DrawString(Textures.SpriteFont, description, new Vector2(statsBoxPos.X + padding, statsBoxPos.Y + padding), Color.Black);
        }

        #endregion
    }
}
