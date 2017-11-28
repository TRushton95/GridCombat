namespace GridCombat.Abilities.Effects
{
    #region Usings

    using System;
    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using Ticks;

    #endregion

    class HoTEffect : IEffect
    {
        #region Constructors

        public HoTEffect(int value, int duration)
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

        #endregion

        #region Methods

        public void Execute(Hero caster, Tile targetTile)
        {
            Hero target = targetTile.Occuptant;

            if (target == null)
            {
                Console.WriteLine("No target on effect execute method.");
                return;
            }

            foreach (BaseTick tick in target.Ticks)
            {
                if (tick.GetType() == typeof(HealTick))
                {
                    Console.WriteLine("Target already has a HealTick");
                    return;
                }
            }

            targetTile.Occuptant.Ticks.Add(
                new HealTick(Value, Duration, target));
        }

        public string GetDescription()
        {
            string result = "Heals " + Value + " health per turn for " + Duration + " turns.";

            return result;
        }

        #endregion
    }
}
