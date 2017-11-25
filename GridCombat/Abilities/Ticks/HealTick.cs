namespace GridCombat.Abilities.Ticks
{
    #region Usings

    using Actors;
    using Effects;

    #endregion

    class HealTick : BaseTick
    {
        #region Constructors

        public HealTick(int value, int duration, Hero target)
            : base(duration)
        {
            this.Value = value;
            this.Target = target;
        }

        #endregion

        #region Properties

        public int Value
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

        public override void Tick()
        {
            BaseEffects.Heal(Target, Value);
        }

        #endregion
    }
}
