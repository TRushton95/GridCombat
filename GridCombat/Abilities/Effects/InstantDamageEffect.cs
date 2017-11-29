namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;
    using GridCombat.Interfaces;

    #endregion

    class InstantDamageEffect : BaseEffect, IEffect
    {
        #region Constructors

        public InstantDamageEffect(int value, TargetType targetType, int casterId)
            : base(targetType, casterId)
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
            if (!ValidateTarget(targetTile))
            {
                return;
            }

            AtomicEffects.Damage(targetTile.Occuptant, Value);
        }

        public string GetDescription()
        {
            string result = "Deals " + Value + " damage.";

            return result;
        }

        #endregion
    }
}