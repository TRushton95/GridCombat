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
            target.CurrentHealth -= value;

            if (target.CurrentHealth < 0)
            {
                target.CurrentHealth = 0;
            }
        }

        public static void Heal(Hero target, int value)
        {
            target.CurrentHealth += value;

            if (target.CurrentHealth > target.MaxHealth)
            {
                target.CurrentHealth = target.MaxHealth;
            }
        }

        #endregion

    }
}
