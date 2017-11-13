namespace GridCombat.Actors
{
    #region Usings

    using GridCombat.Enums;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Tile : BaseActor
    {
        #region Fields

        private static float diameter = 50;

        #endregion

        #region Constructors

        public Tile(float posX, float posY, Texture2D texture, TileType tileType)
            : base(diameter, diameter, posX, posY, texture)
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

        #endregion
    }
}
