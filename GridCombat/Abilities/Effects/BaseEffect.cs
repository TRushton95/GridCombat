namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Enums;

    #endregion

    abstract class BaseEffect
    {
        public BaseEffect(TargetType targetType)
        {
            this.TargetType = targetType;
        }

        public TargetType TargetType
        {
            get;
            set;
        }
    }
}
