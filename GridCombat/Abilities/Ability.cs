namespace GridCombat.Abilities
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
    using System.Text;

    #endregion

    class Ability : BaseInstance
    {
        #region Constructors

        public Ability(string name, List<IEffect> effects, int cost, TargetType targetType, BaseTemplate template, Texture2D icon, int casterId)
        {
            this.Name = name;
            this.Effects = effects;
            this.Cost = cost;
            this.TargetType = targetType;
            this.Template = template;
            this.Icon = icon;
            this.CasterId = casterId;
        }

        #endregion

        #region Properties

        public Hero Caster
        {
            get;
            set;
        }

        public string Name
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

        public List<Tile> GetAffectedTiles(Tile targetTile)
        {
            return Template.GetAffectedTiles(targetTile);
        }

        public bool Execute(Tile targetTile)
        {
            if (!ValidateTarget(targetTile))
            {
                Console.WriteLine("Cannot execute ability on that target");

                return false;
            }
            
            List<Tile> affectedTiles = Template.GetAffectedTiles(targetTile);

            foreach (Tile tile in affectedTiles)
            {
                foreach (IEffect effect in Effects)
                {
                    effect.Execute(Caster, targetTile);
                }
            }

            Console.WriteLine("Ability executed");

            return true;
        }

        public string GetProfile()
        {
            string result = String.Empty;

            result = String.Concat(result, "Name: " + Name + "\n\n");
            result = String.Concat(result, "Cost: " + Cost + "\n\n");

            foreach (IEffect effect in Effects)
            {
                result = String.Concat(result, effect.GetDescription());

                if (!(effect == Effects[Effects.Count - 1]))
                {
                    result = String.Concat(result, "\n");
                }
            }

            return result;
        }

        #endregion
    }
}
