namespace GridCombat.Abilities.Effects
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;
    using GridCombat.Interfaces;

    #endregion

    class DamageBaseEffect : IBaseEffect
    {
        #region Fields

        private static readonly TargetType targetType = TargetType.Hero;

        #endregion

        #region Constructors

        public DamageBaseEffect(int value)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Execute(Hero caster, Tile targetTile)
        {
            targetTile.Occuptant.Damage(this.Value);
        }

        #endregion
    }
}
