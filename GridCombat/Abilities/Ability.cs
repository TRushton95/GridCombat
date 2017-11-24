namespace GridCombat.Abilities
{
    #region Usings
    
    using System.Collections.Generic;
    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using GridCombat.Enums;
    using GridCombat.Services;
    using System;

    #endregion

    class Ability : BaseInstance
    {
        #region Constructors

        public Ability(Hero caster, List<IEffect> effects, int cost, TargetType targetType)
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

        public List<IEffect> Effects
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

        public bool ValidateTarget(Tile targetTile)
        {
            return TargetValidatorService.Validate(this.Caster, targetTile, this.TargetType);
        }

        public void Execute(Tile targetTile)
        {
            if (!ValidateTarget(targetTile))
            {
                Console.WriteLine("Cannot execute ability on that target");
                return;
            }

            //Get affected tiles
            //Repeat effect execution for each affect tile

            foreach (IEffect effect in Effects)
            {
                effect.Execute(Caster, targetTile);
            }
        }

        #endregion
    }
}
