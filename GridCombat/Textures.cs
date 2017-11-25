namespace GridCombat
{
    #region Usings

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    static class Textures
    {
        #region Constants

        const string WhiteTileName = "WhiteTile";
        const string BlackTileName = "BlackTile";
        const string BlueUnitName = "BlueUnit";
        const string RedUnitName = "RedUnit";

        #endregion

        #region Properties

        public static Texture2D BlackTile;

        public static Texture2D WhiteTile;

        public static Texture2D BlueUnit;

        public static Texture2D RedUnit;

        #endregion

        #region Methods

        public static void Initialise(ContentManager content)
        {
            WhiteTile = content.Load<Texture2D>(WhiteTileName);
            BlackTile = content.Load<Texture2D>(BlackTileName);
            BlueUnit = content.Load<Texture2D>(BlueUnitName);
            RedUnit = content.Load<Texture2D>(RedUnitName);
        }

        #endregion
    }
}
