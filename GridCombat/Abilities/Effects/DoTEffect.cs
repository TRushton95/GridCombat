﻿namespace GridCombat.Abilities.Effects
{
    #region Usings

    using System;
    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using Ticks;
    using GridCombat.Enums;

    #endregion

    class DoTEffect : BaseEffect, IEffect
    {
        #region Constructors

        public DoTEffect(int value, int duration, TargetType targetType, int casterId)
            : base(targetType, casterId)
        {
            this.Value = value;
            this.Duration = duration;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }

        public Hero Target
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

            Hero target = targetTile.Occuptant;

            foreach (BaseTick tick in target.Ticks)
            {
                if (tick.GetType() == typeof(DamageTick))
                {
                    Console.WriteLine("Target already has a DamageTick");
                    return;
                }
            }

            targetTile.Occuptant.Ticks.Add(
                new DamageTick(Value, Duration, target));
        }

        public string GetDescription()
        {
            string result = "Deals " + Value + " damage per turn for " + Duration + " turns.";

            return result;
        }

        #endregion
    }
}
