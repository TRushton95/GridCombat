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

        public AreaAffectTemplate(int diameter)
        {
            this.Diameter = diameter;
        }

        #endregion

        #region Properties

        public int Diameter
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override List<Tile> GetAffectedTiles(Tile targetTile)
        {
            List<Tile> result = new List<Tile>();

            int targetX = Convert.ToInt32(targetTile.PosX);
            int targetY = Convert.ToInt32(targetTile.PosY);

            for (int x = targetX - Diameter; x < targetX + Diameter; x++)
            {
                for (int y = targetY - Diameter; y < targetY + Diameter; y++)
                {
                    if (Board.Tiles[x] != null && Board.Tiles[x][y] != null)
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
