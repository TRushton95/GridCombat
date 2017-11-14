namespace GridCombat.Abilities
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using GridCombat.Actors;
    using GridCombat.Interfaces.Effects;
    using GridCombat.Enums;
    using GridCombat.Services;

    #endregion

    class Ability
    {
        #region Constructors

        public Ability(Hero caster, List<IBaseEffect> effects, int cost, TargetType targetType)
        {
            this.Caster = caster;
            this.Effects = effects;
            this.Cost = cost;
            this.TargetType = targetType;
        }

        #endregion

        #region Properties

        public Hero Caster
        {
            get;
            set;
        }

        public List<IBaseEffect> Effects
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public TargetType TargetType
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Cast(Hero caster, Tile targetTile)
        {
            try
            {
                foreach(IBaseEffect effect in Effects)
                {
                    effect.Execute();
                }
            }
            catch (NullReferenceException ex)
            {
                string result = String.Format("An error occured on ability cast: " + ex);

                Console.WriteLine(result);
            }
        }

        public bool ValidateTarget(Tile targetTile)
        {
            return TargetValidatorService.Validate(this.Caster, targetTile, this.TargetType);
        }

        #endregion
    }
}
