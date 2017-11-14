namespace GridCombat.Interfaces
{
    #region usings

    using GridCombat.Actors;
    using GridCombat.Enums;

    #endregion

    interface IEffect
    {
        void Execute(Hero caster, Tile targetTile);
    }
}
