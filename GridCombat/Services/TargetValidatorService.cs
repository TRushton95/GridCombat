namespace GridCombat.Services
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;

    #endregion

    static class TargetValidatorService
    {
        public static bool Validate(Hero caster, Tile targetTile, TargetType targetType)
        {
            bool result = false;

            switch (targetType)
            {
                case TargetType.EmptyTile:
                    result = ValidateEmptyTile(caster, targetTile);
                    break;

                case TargetType.Hero:
                    result = ValidateHero(caster, targetTile);
                    break;

                case TargetType.Self:
                    result = ValidateSelf(caster, targetTile);
                    break;

                case TargetType.Enemy:
                    result = ValidateEnemy(caster, targetTile);
                    break;

                case TargetType.Ally:
                    result = ValidateAlly(caster, targetTile);
                    break;
            }

            return result;
        }

        private static bool ValidateEmptyTile(Hero caster, Tile targetTile)
        {
            if (targetTile.Occuptant == null)
            {
                return true;
            }

            return false;
        }

        private static bool ValidateHero(Hero caster, Tile targetTile)
        {
            Hero occupant = targetTile.Occuptant;

            if (occupant != null && (occupant.GetType() == typeof(Hero)))
            {
                return true;
            }

            return false;
        }

        private static bool ValidateSelf(Hero caster, Tile targetTile)
        {
            Hero occupant = targetTile.Occuptant;

            if (occupant != null && (occupant == caster))
            {
                return true;
            }

            return false;
        }

        private static bool ValidateEnemy(Hero caster, Tile targetTile)
        {
            Hero occupant = targetTile.Occuptant;

            if (occupant != null && (occupant.Team != caster.Team))
            {
                return true;
            }

            return false;
        }

        private static bool ValidateAlly(Hero caster, Tile targetTile)
        {
            Hero occupant = targetTile.Occuptant;

            if (occupant != null && (occupant.Team == caster.Team))
            {
                return true;
            }

            return false;
        }
    }
}
