namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;

    #endregion

    class HoTEffect
    {
        #region Fields

        private HealBaseEffect healBaseEffect;

        #endregion

        #region Constructors

        public HoTEffect(int value, int duration)
        {
            this.Value = value;
            this.Duration = duration;
            healBaseEffect = new HealBaseEffect(value);
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
            Target.Heal(this.Value);
        }

        #endregion
    }
}
