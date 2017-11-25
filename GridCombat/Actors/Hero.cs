namespace GridCombat.Actors
{
    #region Usings

    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;
    using GridCombat.Abilities;
    using Abilities.Ticks;

    #endregion

    class Hero : BaseActor
    {
        #region Fields

        private static float diameter = 50;

        #endregion

        #region Constructors

        public Hero(int maxHealth, int maxEnergy, int posX, int posY, int team, Texture2D texture)
            : base(posX, posY, texture)
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

        public List<BaseTick> Ticks
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void CastAbility(Tile targetTile, int abilitySlot)
        {
            if (Abilities[abilitySlot] != null)
            {
                Abilities[abilitySlot].Execute(targetTile);
            }
        }

        public void NewTurn()
        {
            CurrentEnergy = MaxEnergy;
        }

        public void EndTurn()
        {
            foreach (BaseTick tick in Ticks)
            {
                tick.Tick();
            }
        }

        #endregion
    }
}
