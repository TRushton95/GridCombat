namespace GridCombat.Abilities.Ticks
{
    abstract class BaseTick
    {
        #region Constructors

        public BaseTick(int duration)
        {
            this.Duration = duration;
        }

        #endregion

        #region Properties

        public int Duration
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public virtual void Tick()
        {
        }

        #endregion
    }
}
