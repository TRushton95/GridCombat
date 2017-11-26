﻿namespace GridCombat
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
        public const int HighlightBorderWidth = 3;

        #endregion

        #region Fields

        private static Board _instance;

        #endregion

        #region Constructors

        public Board()
        {
            Tiles = new List<List<Tile>>();
            Heroes = new List<Hero>();
        }
        
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

        public Tile HighlightedTile
        {
            get;
            set;
        }

        public Hero SelectedHero
        {
            get;
            set;
        }

        public Hero HighlightedHero
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

        public void MoveHero(Hero hero, int x, int y)
        {
            if (IsValidTile(x, y) && Tiles[x][y].Occuptant == null)
            {
                Tiles[hero.PosX][hero.PosY].Occuptant = null;
                hero.PosX = x;
                hero.PosY = y;
                Tiles[x][y].Occuptant = hero;
            }
        }

        public void SpawnHero(Hero hero)
        {
            int x = hero.PosX;
            int y = hero.PosY;

            if (IsValidTile(x, y) && Tiles[x][y].Occuptant == null)
            {
                Heroes.Add(hero);
                Tiles[x][y].Occuptant = hero;
            }
        }

        private void GenerateTiles()
        {
            List<List<Tile>> result = new List<List<Tile>>();

            for (int x = 0; x < Width; x++)
            {
                List<Tile> column = new List<Tile>();

                for (int y = 0; y < Height; y++)
                {
                    column.Add(new Tile(x, y, TileType.Ground, Textures.WhiteTile));
                }

                result.Add(column);
            }

            Tiles = result;
        }

        private void GenerateHeroes()
        {
            SpawnHero(new Hero(10, 10, 0, 0, 1, Textures.BlueUnit));
            SpawnHero(new Hero(10, 10, Width - 1, Height - 1, 2, Textures.RedUnit));
        }

        public void Generate()
        {
            GenerateTiles();
            GenerateHeroes();
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

        public Tile GetTileAtCanvasPosition(int x, int y)
        {
            foreach (List<Tile> column in Tiles)
            {
                foreach (Tile tile in column)
                {
                    int canvasX = tile.PosX * Tile.diameter;
                    int canvasY = tile.PosY * Tile.diameter;

                    if (x > canvasX && x < canvasX + Tile.diameter &&
                        y > canvasY && y < canvasY + Tile.diameter)
                    {
                        return tile;
                    }
                }
            }

            return null;
        }

        public Hero GetHeroAtCanvasPosition(int x, int y)
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

        private bool IsValidTile(int x, int y)
        {
            if (Tiles[x] != null && Tiles[x][y] != null)
            {
                return true;
            }

            return false;
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

            if (HighlightedTile != null)
            {
                spriteBatch.Draw(
                    Textures.TileHighlight, 
                    new Vector2((HighlightedTile.PosX * Tile.diameter) + HighlightBorderWidth, (HighlightedTile.PosY * Tile.diameter) + HighlightBorderWidth), 
                    Color.White);
            }

            int offset = (Tile.diameter / 2) - (Hero.diameter / 2);

            foreach (Hero hero in Heroes)
            {
                hero.Draw(spriteBatch, (hero.PosX * Tile.diameter) + offset, (hero.PosY * Tile.diameter) + offset);
            }

            if (SelectedHero != null)
            {
                spriteBatch.Draw(
                    Textures.SelectedHero, 
                    new Vector2((SelectedHero.PosX * Tile.diameter) + offset - HighlightBorderWidth, (SelectedHero.PosY * Tile.diameter) + offset - HighlightBorderWidth), 
                    Color.White);
                StatsBox.Draw(spriteBatch, SelectedHero, true);
            }

            if (HighlightedHero != null && HighlightedHero != SelectedHero)
            {
                StatsBox.Draw(spriteBatch, HighlightedHero, false);
            }
        }

        #endregion
    }
}
