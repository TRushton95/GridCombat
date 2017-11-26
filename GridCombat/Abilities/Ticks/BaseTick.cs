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

        public void Tick()
        {
            Duration--;

        }

        public virtual void TickResolution()
        {
        }

        #endregion
    }
}
