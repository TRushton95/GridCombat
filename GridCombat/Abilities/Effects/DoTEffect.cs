namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;

    #endregion

    class DoTEffect
    {
        #region Fields

        private DamageBaseEffect damageBaseEffect;

        #endregion

        #region Constructors

        public DoTEffect(int value, int duration)
        {
            this.Value = value;
            this.Duration = duration;
            damageBaseEffect = new DamageBaseEffect(value);
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

        public void Tick()
        {
            Target.Damage(this.Value);
        }

        #endregion
    }
}
