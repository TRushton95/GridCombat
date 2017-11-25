namespace GridCombat
{
    #region Usings

    using GridCombat.Actors;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;

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

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Tile> row in Tiles)
            {
                foreach (Tile tile in row)
                {
                    tile.Draw(spriteBatch);
                }
            }

            foreach(Hero hero in Heroes)
            {
                hero.Draw(spriteBatch);
            }
        }

        #endregion
    }
}
