namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;

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

        public Hero Target
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Execute(Hero caster, Tile targetTile)
        {
            //Apply effect to target effect queue
        }

        public void Tick()
        {
            BaseEffects.Heal(Target, Value);

            Duration--;
        }

        #endregion
    }
}
