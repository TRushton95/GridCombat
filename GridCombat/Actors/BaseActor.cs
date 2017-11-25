namespace GridCombat
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Actors;

    #endregion

    abstract class BaseActor : BaseInstance
    {
        #region Constructors

        public BaseActor(int posX, int posY, Texture2D texture)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Texture = texture;
        }

        #endregion

        #region Properties

        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }

        public float CanvasX
        {
            get
            {
                return (PosX * Tile.diameter) + (Tile.diameter / 4);
            }
        }

        public float CanvasY
        {
            get
            {
                return PosY * Tile.diameter + (Tile.diameter / 4);
            }
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
            spriteBatch.Draw(this.Texture, new Vector2(CanvasX, CanvasY), Color.White);
        }

        #endregion
    }
}
