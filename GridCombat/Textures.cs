namespace GridCombat
{
    #region Usings

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Textures
    {
        #region Constants

        //Tiles and Units
        const string WhiteTileName = "WhiteTile";
        const string BlackTileName = "BlackTile";
        const string BlueUnitName = "BlueUnit";
        const string RedUnitName = "RedUnit";

        //Fonts
        const string SpriteFontName = "Font";
        
        //UI
        const string StatsBoxName = "StatsBox";

        //Ability Icons



        #endregion

        #region Fields

        private static Textures _instance;

        #endregion

        #region Properties

        public static Texture2D BlackTile;

        public static Texture2D WhiteTile;

        public static Texture2D BlueUnit;

        public static Texture2D RedUnit;

        public static SpriteFont SpriteFont;

        public static Texture2D StatsBox;

        public static Textures Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Textures();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        public void Initialise(ContentManager content)
        {
            WhiteTile = content.Load<Texture2D>(WhiteTileName);
            BlackTile = content.Load<Texture2D>(BlackTileName);
            BlueUnit = content.Load<Texture2D>(BlueUnitName);
            RedUnit = content.Load<Texture2D>(RedUnitName);
            SpriteFont = content.Load<SpriteFont>(SpriteFontName);
            StatsBox = content.Load<Texture2D>(StatsBoxName);
        }

        #endregion
    }
}
