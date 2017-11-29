namespace GridCombat.UI.Components
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class EndTurnBox : BaseInstance
    {
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
                return Spellbar.PosX + (Textures.Spellbar.Width + 50);
            }
        }

        public static int PosY
        {
            get
            {
                return Spellbar.PosY;
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

        public static void Draw(SpriteBatch spriteBatch)
        {
            string message = "End turn";

            Vector2 boxCoordinates = new Vector2(PosX, PosY);

            Vector2 textCoordinates = new Vector2(boxCoordinates.X + (Width / 2) - (Textures.SpriteFont.MeasureString(message).X / 2),
                                                    boxCoordinates.Y + (Height / 2) - (Textures.SpriteFont.MeasureString(message).Y) / 2);

            spriteBatch.Draw(Textures.EndTurnBox, boxCoordinates, Color.White);
            spriteBatch.DrawString(Textures.SpriteFont, message, textCoordinates, Color.Black);
        }

        #endregion
    }
}
