namespace GridCombat
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    abstract class BaseActor
    {
        #region Constructors

        public BaseActor(float width, float height, float posX, float posY, Texture2D texture)
        {
            this.Width = width;
            this.Height = height;
            this.PosX = posX;
            this.PosY = posY;
            this.Texture = texture;
        }

        #endregion

        #region Properties

        public float Width
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

        public float PosX
        {
            get;
            set;
        }

        public float PosY
        {
            get;
            set;
        }

        public Texture2D Texture
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Vector2(this.PosX, this.PosY), Color.White);
        }

        #endregion
    }
}
