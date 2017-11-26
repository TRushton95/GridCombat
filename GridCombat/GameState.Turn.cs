namespace GridCombat
{
    #region Usings

    using GridCombat.Abilities.Ticks;
    using GridCombat.Actors;
    using System.Collections.Generic;

    #endregion

    partial class GameState : BaseInstance
    {
        #region Properties

        public int Turn
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void StartPlayerTurn(int player)
        {
            List<Hero> heroes = Board.GetHeroesByPlayer(player);

            foreach (Hero hero in heroes)
            {
                hero.CurrentEnergy = hero.MaxEnergy;
                ResolveTicks(hero);
            }
        }

        public void EndPlayerTurn(int player)
        {

        }

        public void StartTurn()
        {
            Turn++;
        }

        public void EndTurn()
        {

        }

        private void ResolveTicks(Hero hero)
        {
            foreach (BaseTick tick in hero.Ticks)
            {
                tick.Tick();
            }
        }

        #endregion
    }
}
