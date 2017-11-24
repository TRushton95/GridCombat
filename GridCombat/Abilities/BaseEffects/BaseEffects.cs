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
            target.DealDamage(value);
        }

        public static void Heal(Hero target, int value)
        {
            target.DealHeal(value);
        }

        #endregion

    }
}
