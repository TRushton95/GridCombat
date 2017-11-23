namespace GridCombat
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Abilities;
    using System.Collections.Generic;
    using GridCombat.Interfaces;

    #endregion

    class Board
    {
        #region Fields

        private static Board _instance;

        #endregion

        #region Properties

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public List<List<Tile>> Tiles
        {
            get;
            set;
        }

        public List<Hero> Heroes
        {
            get;
            set;
        }

        public static Board Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Board();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        

        #endregion
    }
}
