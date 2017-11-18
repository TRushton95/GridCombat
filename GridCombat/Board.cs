namespace GridCombat
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Abilities;
    using System.Collections.Generic;
    using GridCombat.Interfaces;

    #endregion

    class Board
    {
        #region Properties

        public List<List<Tile>> Tiles
        {
            get;
            set;
        }

        public List<Hero> Heroes
        {
            get;
            set;
        }

        #endregion

        #region Methods

        //Called when board picks up new ability pushed into the ability queue
        public void ExecuteAbility(Ability ability, Tile targetTile)
        {
            foreach (IEffect effect in ability.Effects)
            {
                effect.Execute(ability.Caster, targetTile);
            }
        }

        #endregion
    }
}
