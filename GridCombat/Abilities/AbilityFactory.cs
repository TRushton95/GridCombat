namespace GridCombat.Abilities.Instances
{
    #region Usings

    using GridCombat.Abilities.Effects;
    using GridCombat.Interfaces;
    using System.Collections.Generic;
    using GridCombat.Enums;
    using GridCombat.Templates;

    #endregion

    static class AbilityFactory
    {
        public static Ability Fireball(int casterId)
        {
            Ability result = new Ability(
                "Rain of a Thousand Flames",
                new List<IEffect> {
                    new InstantDamageEffect(2, TargetType.Enemy, casterId),
                    new DoTEffect(1, 3, TargetType.Enemy, casterId) },
                3,
                TargetType.Enemy,
                new AreaAffectTemplate(2),
                Textures.FireballIcon,
                casterId);

            return result;
        }

        public static Ability Regrowth(int casterId)
        {
            Ability result = new Ability(
                "Regrowth",
                new List<IEffect> {
                    new HoTEffect(2, 3, TargetType.Ally, casterId) },
                3,
                TargetType.Ally,
                new SingleTargetTemplate(),
                Textures.RegrowthIcon,
                casterId);

            return result;
        }

        public static Ability Shoot(int casterId)
        {
            Ability result = new Ability(
                "Shoot",
                new List<IEffect> {
                    new InstantDamageEffect(4, TargetType.Enemy, casterId) },
                3,
                TargetType.Enemy,
                new SingleTargetTemplate(),
                Textures.ShootIcon,
                casterId);

            return result;
        }

        public static Ability Heal(int casterId)
        {
            Ability result = new Ability(
                "Heal",
                new List<IEffect> {
                    new InstantHealEffect(4, TargetType.Ally, casterId) },
                3,
                TargetType.Ally,
                new SingleTargetTemplate(),
                Textures.HealIcon,
                casterId);

            return result;
        }
    }
}
