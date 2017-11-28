using GridCombat.Abilities;
using GridCombat.Interfaces;

namespace GridCombat.UI.States
{
    class TargetingState : BaseInstance, IUIState
    {
        #region Fields

        public Ability selectedAbility;

        #endregion

        #region Constructors

        public TargetingState(Ability selectedAbility)
        {
            this.selectedAbility = selectedAbility;
        }

        #endregion

        public IUIState HandleInput(MouseState mouseState, MouseState prevMouseState)
        {

        }
    }
}
