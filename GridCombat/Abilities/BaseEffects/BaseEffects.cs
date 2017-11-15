namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;

    #endregion

    static class BaseEffects
    {
        #region Methods

        public static void Damage(Hero target, int value)
        {
            target.Damage(value);
        }

        public static void Heal(Hero target, int value)
        {
            target.Heal(value);
        }

        #endregion

    }
}
