namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;

    #endregion

    class InstantHealEffect : IEffect
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
            AtomicEffects.Heal(targetTile.Occuptant, Value);
        }

        public string GetDescription()
        {
            string result = "Heals " + Value + " health.";

            return result;
        }

        #endregion
    }
}
