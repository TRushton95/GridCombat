namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;

    #endregion

    class InstantHealEffect
    {
        #region Constructors

        public InstantHealEffect(int value)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Execute(Hero caster, Tile targetTile)
        {
            targetTile.Occuptant.Heal(this.Value);
        }

        #endregion
    }
}
