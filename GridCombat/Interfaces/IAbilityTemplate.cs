namespace GridCombat.Interfaces.Effects
{
    #region Usings

    using GridCombat.Actors;
    using System.Collections.Generic;

    #endregion

    interface IAbilityTemplate
    {
        void GetAffectedTiles(List<List<Tile>> tiles);
    }
}
