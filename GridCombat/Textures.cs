namespace GridCombat
{
    using Microsoft.Xna.Framework;
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
        const string TileHighlightname = "TileHighlight";
        const string SelectedHeroName = "SelectedHero";

        //Fonts
        const string SpriteFontName = "Font";
        
        //UI
        const string StatsBoxName = "StatsBox";
        const string SpellbarName = "Spellbar";

        //Ability Icons
        const string FireballName = "Fireball";
        const string HealName = "Heal";
        const string RegrowthName = "Regrowth";
        const string ShootName = "Shoot";
        const string SelectedAbilityName = "SelectedAbility";


        #endregion

        #region Fields

        private static Textures _instance;

        #endregion

        #region Properties

        //Tiles and Units
        public static Texture2D BlackTile;

        public static Texture2D WhiteTile;

        public static Texture2D BlueUnit;

        public static Texture2D RedUnit;

        public static Texture2D TileHighlight;

        public static Texture2D SelectedHero;

        //Fonts
        public static SpriteFont SpriteFont;

        //UI
        public static Texture2D StatsBox;

        public static Texture2D Spellbar;

        //Ability Icons
        public static Texture2D FireballIcon;

        public static Texture2D HealIcon;

        public static Texture2D RegrowthIcon;

        public static Texture2D ShootIcon;

        public static Texture2D SelectedAbility;

        
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
            //Tiles and Units
            WhiteTile = content.Load<Texture2D>(WhiteTileName);
            BlackTile = content.Load<Texture2D>(BlackTileName);
            BlueUnit = content.Load<Texture2D>(BlueUnitName);
            RedUnit = content.Load<Texture2D>(RedUnitName);
            TileHighlight = content.Load<Texture2D>(TileHighlightname);
            SelectedHero = content.Load<Texture2D>(SelectedHeroName);

            //Fonts
            SpriteFont = content.Load<SpriteFont>(SpriteFontName);

            //UI
            StatsBox = content.Load<Texture2D>(StatsBoxName);
            Spellbar = content.Load<Texture2D>(SpellbarName);

            //Ability Icons
            FireballIcon = content.Load<Texture2D>(FireballName);
            HealIcon = content.Load<Texture2D>(HealName);
            ShootIcon = content.Load<Texture2D>(ShootName);
            RegrowthIcon = content.Load<Texture2D>(RegrowthName);
            SelectedAbility = content.Load<Texture2D>(SelectedAbilityName);
        }

        #endregion
    }
}
