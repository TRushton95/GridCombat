namespace GridCombat.Actors
{
    #region Usings

    using GridCombat.Enums;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Tile : BaseActor
    {
        #region Fields

        public static float diameter = 50;

        #endregion

        #region Constructors

        public Tile(int posX, int posY, Texture2D texture, TileType tileType)
            : base(posX, posY, texture)
        {
            this.TileType = tileType;
        }

        #endregion

        #region Methods

        public TileType TileType
        {
            get;
            set;
        }

        public Hero Occuptant
        {
            get;
            set;
        }

        #endregion
    }
}
