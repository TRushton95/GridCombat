namespace GridCombat.Templates
{
    #region

    using GridCombat.Actors;
    using System.Collections.Generic;

    #endregion

    class SingleTargetTemplate : BaseTemplate
    {
        #region Methods

        public override List<Tile> GetAffectedTiles(Tile targetTile)
        {
            List<Tile> result = new List<Tile>();

            result.Add(targetTile);

            return result;
        }

        #endregion
    }
}
