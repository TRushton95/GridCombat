namespace GridCombat
{
    #region Usings

    using Enums;
    using GridCombat.Actors;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Board
    {
        #region Constants

        public const int Width = 20;
        public const int Height = 15;

        #endregion

        #region Fields

        private static Board _instance;

        #endregion

        #region Properties

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

        private List<List<Tile>> GenerateTiles()
        {
            List<List<Tile>> result = new List<List<Tile>>();

            for (int x = 0; x < Width; x++)
            {
                List<Tile> column = new List<Tile>();

                for (int y = 0; y < Height; y++)
                {
                    column.Add(new Tile(x, y, TileType.Ground));
                }

                result.Add(column);
            }

            return result;
        }

        private List<Hero> GenerateHeroes()
        {
            List<Hero> result = new List<Hero>();

            result.Add(new Hero(10, 10, 0, 0, 1));
            result.Add(new Hero(10, 10, Width - 1, Height - 1, 2));

            return result;
        }

        public void Generate()
        {
            Tiles = GenerateTiles();
            Heroes = GenerateHeroes();
        }

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
