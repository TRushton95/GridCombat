namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;
    using GridCombat.Services;

    #endregion

    abstract class BaseEffect : BaseInstance
    {
        public BaseEffect(TargetType targetType, int casterId)
        {
            this.TargetType = targetType;
            this.CasterId = casterId;
        }

        public TargetType TargetType
        {
            get;
            set;
        }

        public int CasterId
        {
            get;
            set;
        }

        protected bool ValidateTarget(Tile targetTile)
        {
            return TargetValidatorService.Validate(Board.GetHeroById(CasterId), targetTile, this.TargetType);
        }
    }
}
