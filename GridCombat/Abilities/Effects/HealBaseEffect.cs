﻿namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;
    using GridCombat.Interfaces;

    #endregion

    class HealBaseEffect : IBaseEffect
    {
        #region Fields

        private static readonly TargetType targetType = TargetType.Hero;

        #endregion

        #region Constructors

        public HealBaseEffect(int heal)
        {
            this.Heal = heal;
        }

        #endregion

        #region Properties

        public int Heal
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Execute(Hero caster, Tile targetTile)
        {
            targetTile.Occuptant.Heal(this.Heal);
        }

        #endregion

    }
}
