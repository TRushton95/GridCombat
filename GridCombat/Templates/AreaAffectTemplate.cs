namespace GridCombat.Templates
{
    #region

    using System.Collections.Generic;
    using GridCombat.Actors;
    using System;

    #endregion

    class AreaAffectTemplate : BaseTemplate
    {
        #region Constructors

        public AreaAffectTemplate(int radius)
        {
            this.Radius = radius;
        }

        #endregion

        #region Properties

        public int Radius
        {
            get;
            set;
        }

        private int Diameter
        {
            get
            {
                return (Radius * 2) + 1;
            }
        }

        #endregion

        #region Methods

        public override List<Tile> GetAffectedTiles(Tile targetTile)
        {

            int targetX = targetTile.PosX;
            int targetY = targetTile.PosY;

            int initX = targetX - Radius;
            int initY = targetY - Radius;

            List<Tile> result = new List<Tile>();

            for (int x = initX; x <= targetX + Radius; x++)
            {
                for (int y = initY; y <= targetY + Radius; y++)
                {
                    if (x >= 0 && x < Board.Tiles.Count &&
                        Board.Tiles[x] != null &&
                        y >= 0 && y < Board.Tiles[x].Count &&
                        Board.Tiles[x][y] != null)
                    {
                        result.Add(Board.Tiles[x][y]);
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
