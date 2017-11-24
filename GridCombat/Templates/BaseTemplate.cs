namespace GridCombat.Templates
{
    #region Usings

    using GridCombat.Actors;
    using System.Collections.Generic;

    #endregion

    abstract class BaseTemplate : BaseInstance
    {
        public virtual List<Tile> GetAffectedTiles(Tile targetTile)
        {
            return new List<Tile>();
        }
    }
}
