﻿namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;

    #endregion

    class InstantDamageEffect : IEffect
    {
        #region Constructors

        public InstantDamageEffect(int value)
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