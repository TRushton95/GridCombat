namespace GridCombat.UI.Components
{
    #region Usings

    using GridCombat.Abilities;
    using GridCombat.Actors;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Spellbar : BaseInstance
    {
        #region Constants

        private const int BorderWidth = 1;

        #endregion

        #region Methods

        public static void Draw(SpriteBatch spriteBatch, Hero hero, int? selectedAbility = null)
        {
            Texture2D spellbarTexture = Textures.Spellbar;

            Rectangle destinationRect = new Rectangle(
                ((Board.Width * Tile.diameter) / 2) - (spellbarTexture.Width / 2), 
                (Board.Height * Tile.diameter) + 10, 
                (int)spellbarTexture.Width, 
                (int)spellbarTexture.Height);

            spriteBatch.Draw(spellbarTexture, destinationRect, Color.White);

            int offset = 0;

            foreach (Ability ability in hero.Abilities)
            {
                spriteBatch.Draw(
                    ability.Icon,
                    new Vector2(destinationRect.Left + BorderWidth + offset, destinationRect.Top + BorderWidth),
                    Color.White);
                
                offset += ability.Icon.Width;
            }
        }

        #endregion
    }
}
