namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Interfaces;

    #endregion

    class DoTEffect : IEffect
    {
        #region Constructors

        public DoTEffect(int value, int duration)
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
            BaseEffects.Damage(Target, Value);

            Duration--;
        }

        #endregion
    }
}
