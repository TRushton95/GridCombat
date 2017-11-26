namespace GridCombat
{
    #region Usings

    using GridCombat.Interfaces;
    using GridCombat.UI.States;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    partial class GameState : BaseInstance
    {
        #region Fields

        public MouseState mouseState;
        public MouseState prevMouseState;

        #endregion

        #region Properties

        public int CurrentPlayer
        {
            get;
            set;
        }

        public int Players
        {
            get;
            set;
        }

        public IUIState UIState
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void LoadTextures(ContentManager contentManager)
        {
            Textures.Initialise(contentManager);
        }

        public void StartGame(int players)
        {
            Board.Generate();
            this.Players = players;
            this.CurrentPlayer = 0;
            this.Turn = 0;
            this.UIState = new UnselectedState();
        }

        public void Update()
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            IUIState newState = UIState.HandleInput(mouseState, prevMouseState);

            if (newState != null)
            {
                UIState.OnLeave();
                UIState = newState;
                UIState.OnEnter();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Board.Draw(spriteBatch);
        }

        #endregion
    }
}
