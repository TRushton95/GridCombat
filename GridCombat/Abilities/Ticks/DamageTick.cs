namespace GridCombat.Abilities.Ticks
{
    #region Usings

    using Actors;
    using Effects;

    #endregion

    class DamageTick : BaseTick
    {
        #region Constructors

        public DamageTick(int value, int duration, Hero target)
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
            BaseEffects.Damage(Target, Value);
        }

        #endregion
    }
}
