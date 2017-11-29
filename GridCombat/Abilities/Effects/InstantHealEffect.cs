namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;
    using GridCombat.Interfaces;

    #endregion

    class InstantHealEffect : BaseEffect, IEffect
    {
        #region Constructors

        public InstantHealEffect(int value, TargetType targetType)
            : base(targetType)
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
