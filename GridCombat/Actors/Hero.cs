namespace GridCombat.Actors
{
    #region Usings

    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Hero : BaseActor
    {
        #region Fields

        private static float diameter = 50;

        #endregion

        #region Constructors

        public Hero(int maxHealth, int maxEnergy, float posX, float posY, Texture2D texture)
            : base(diameter, diameter, posX, posY, texture)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = maxHealth;
            this.MaxEnergy = maxEnergy;
            this.CurrentEnergy = maxEnergy;
        }

        #endregion

        #region Properties

        public int MaxHealth
        {
            get;
            set;
        }

        public int MaxEnergy
        {
            get;
            set;
        }

        public int CurrentHealth
        {
            get;
            set;
        }

        public int CurrentEnergy
        {
            get;
            set;
        }

        #endregion
    }
}
