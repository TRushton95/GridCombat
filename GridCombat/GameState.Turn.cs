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

        public int CurrentPlayer
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void NextPlayerTurn()
        {
            CurrentPlayer++;

            if (CurrentPlayer >= Players)
            {
                CurrentPlayer = 1;
                NextGameTurn();
            }

            List<Hero> heroes = Board.GetHeroesByPlayer(CurrentPlayer);

            foreach (Hero hero in heroes)
            {
                hero.CurrentEnergy = hero.MaxEnergy;
                ResolveTicks(hero);
            }
        }

        public void NextGameTurn()
        {
            Turn++;
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
