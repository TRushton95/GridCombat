﻿namespace GridCombat.Abilities
{
    #region Usings
    
    using System.Collections.Generic;
    using GridCombat.Actors;
    using GridCombat.Interfaces;
    using GridCombat.Enums;
    using GridCombat.Services;
    using System;
    using GridCombat.Templates;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class Ability : BaseInstance
    {
        #region Constructors

        public Ability(List<IEffect> effects, int cost, TargetType targetType, BaseTemplate template, Texture2D icon, int casterId)
        {
            this.Effects = effects;
            this.Cost = cost;
            this.TargetType = targetType;
            this.Template = template;
            this.Icon = icon;
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

        public BaseTemplate Template
        {
            get;
            set;
        }

        public Texture2D Icon
        {
            get;
            set;
        }

        public int CasterId
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public bool ValidateTarget(Tile targetTile)
        {
            return TargetValidatorService.Validate(Board.GetHeroById(CasterId), targetTile, this.TargetType);
        }

        public void Execute(Tile targetTile)
        {
            if (!ValidateTarget(targetTile))
            {
                Console.WriteLine("Cannot execute ability on that target");
                return;
            }
            
            List<Tile> affectedTiles = Template.GetAffectedTiles(targetTile);

            foreach (Tile tile in affectedTiles)
            {
                foreach (IEffect effect in Effects)
                {
                    effect.Execute(Caster, targetTile);
                }
            }
        }

        #endregion
    }
}
