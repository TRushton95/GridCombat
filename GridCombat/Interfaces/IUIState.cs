namespace GridCombat.Interfaces
{
    #region Usings

    using Microsoft.Xna.Framework.Input;

    #endregion

    interface IUIState
    {
        IUIState HandleInput(MouseState mouseState, MouseState prevMouseState, int currentPlayer);

        void OnEnter();

        void OnLeave();
    }
}
