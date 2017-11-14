namespace GridCombat.Interfaces
{
    #region usings

    using GridCombat.Actors;
    using GridCombat.Enums;

    #endregion

    interface IBaseEffect
    {
        void Execute(Hero caster, Tile targetTile);
    }
}
