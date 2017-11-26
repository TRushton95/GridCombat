namespace GridCombat.Interfaces
{
    #region Usings

    using Microsoft.Xna.Framework.Input;

    #endregion

    interface IUIState
    {
        IUIState HandleInput(MouseState mouseState, MouseState prevMouseState);

        void OnEnter();

        void OnLeave();
    }
}
