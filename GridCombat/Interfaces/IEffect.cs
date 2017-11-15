namespace GridCombat.Interfaces
{
    #region Usings

    using GridCombat.Actors;

    #endregion

    interface IEffect
    {
        void Execute(Hero caster, Tile target);
    }
}
