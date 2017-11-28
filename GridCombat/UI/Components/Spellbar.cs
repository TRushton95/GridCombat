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

        #endregion

        #region Properties

        public static Texture2D Texture
        {
            get
            {
                return Textures.Spellbar;
            }
        }

        public static int PosX
        {
            get
            {
                return ((Board.Width * Tile.diameter) / 2) - (Texture.Width / 2);
            }
        }

        public static int PosY
        {
            get
            {
                return (Board.Height * Tile.diameter) + 10;
            }
        }

        public static int Width
        {
            get
            {
                return Texture.Width;
            }
        }
        public static int Height
        {
            get
            {
                return Texture.Height;
            }
        }

        #endregion

        #region Methods

        public static void Draw(SpriteBatch spriteBatch, Hero hero, int? selectedAbility = null)
        {
            Rectangle destinationRect = new Rectangle(PosX, PosY, Width, Height);

            spriteBatch.Draw(Texture, destinationRect, Color.White);

            int offset = 0;

            foreach (Ability ability in hero.Abilities)
            {
                spriteBatch.Draw(
                    ability.Icon,
                    new Vector2(destinationRect.Left + BorderWidth + offset, destinationRect.Top + BorderWidth),
                    Color.White);

                if (Board.SelectedAbility == ability)
                {
                    spriteBatch.Draw(
                        Textures.SelectedAbility,
                        new Vector2(destinationRect.Left + BorderWidth + offset, destinationRect.Top + BorderWidth),
                        Color.White);
                }
                
                offset += ability.Icon.Width;
            }
        }

        #endregion
    }
}
