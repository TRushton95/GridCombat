namespace GridCombat.Interfaces
{
    #region usings

    using GridCombat.Actors;

    #endregion

    interface ITargetValidator
    {
        bool Validate(Tile tile);
    }
}
