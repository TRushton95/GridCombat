namespace GridCombat.Actors
{
    #region Usings

    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;
    using GridCombat.Abilities;

    #endregion

    class Hero : BaseActor
    {
        #region Fields

        private static float diameter = 50;

        #endregion

        #region Constructors

        public Hero(int maxHealth, int maxEnergy, float posX, float posY, int team, Texture2D texture)
            : base(diameter, diameter, posX, posY, texture)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = maxHealth;
            this.MaxEnergy = maxEnergy;
            this.CurrentEnergy = maxEnergy;
            this.Team = team;
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

        public int Team
        {
            get;
            set;
        }

        public List<Ability> Abilities
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Cast(Tile targetTile, int abilitySlot)
        {
            //add ability in slot to board queue
        }

        public void DealDamage(int damage)
        {
            this.CurrentHealth -= damage;
        }

        public void DealHeal(int heal)
        {
            this.CurrentHealth += heal;
        }

        #endregion
    }
}
