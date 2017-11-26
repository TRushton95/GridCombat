namespace GridCombat
{
    #region Usings

    using Enums;
    using GridCombat.Actors;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using Microsoft.Xna.Framework;
    using GridCombat.UI;

    #endregion

    class Board
    {
        #region Constants

        public const int Width = 5;
        public const int Height = 5;

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

            Texture2D tileTexture;

            for (int x = 0; x < Width; x++)
            {
                List<Tile> column = new List<Tile>();

                for (int y = 0; y < Height; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        tileTexture = Textures.WhiteTile;
                    }
                    else
                    {
                        tileTexture = Textures.BlackTile;
                    }

                    column.Add(new Tile(x, y, TileType.Ground, tileTexture));
                }

                result.Add(column);
            }

            return result;
        }

        private List<Hero> GenerateHeroes()
        {
            List<Hero> result = new List<Hero>();

            result.Add(new Hero(10, 10, 0, 0, 1, Textures.BlueUnit));
            result.Add(new Hero(10, 10, Width - 1, Height - 1, 2, Textures.RedUnit));

            return result;
        }

        public void Generate()
        {
            Tiles = GenerateTiles();
            Heroes = GenerateHeroes();
        }

        public List<Hero> GetHeroesByPlayer(int player)
        {
            List<Hero> result = new List<Hero>();

            foreach (Hero hero in Heroes)
            {
                if (hero.Team == player)
                {
                    result.Add(hero);
                }
            }

            return result;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Tile> row in Tiles)
            {
                foreach (Tile tile in row)
                {
                    tile.Draw(spriteBatch, tile.PosX * Tile.diameter, tile.PosY * Tile.diameter);
                }
            }

            int offset = (Tile.diameter / 2) - (Hero.diameter / 2);

            foreach (Hero hero in Heroes)
            {
                hero.Draw(spriteBatch, (hero.PosX * Tile.diameter) + offset, (hero.PosY * Tile.diameter) + offset);
            }

            StatsBox.Draw(spriteBatch, Heroes[1]);
        }

        private Hero GetHeroAtCanvasPosition(int x, int y)
        {
            int offset = (Tile.diameter / 2) - (Hero.diameter / 2);

            foreach (Hero hero in Heroes)
            {
                int canvasX = (hero.PosX * Tile.diameter) + offset;
                int canvasY = (hero.PosY * Tile.diameter) + offset;

                if (x > canvasX && x < canvasX + Hero.diameter &&
                    y > canvasY && y < canvasY + Hero.diameter)
                {
                    return hero;
                }
            }

            return null;
        }

        #endregion
    }
}
