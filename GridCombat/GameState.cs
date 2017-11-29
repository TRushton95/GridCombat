namespace GridCombat
{
    #region Usings

    using GridCombat.Interfaces;
    using GridCombat.UI.States;
    using Microsoft.Xna.Framework;
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

        #region Constructors

        public GameState()
        {
            Players = 2;
            CurrentPlayer = 1;
            Turn = 0;
        }

        #endregion

        #region Properties

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
            this.CurrentPlayer = 1;
            this.Turn = 1;
            this.UIState = new UnselectedState();
        }

        public void Update()
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            IUIState newState = UIState.HandleInput(mouseState, prevMouseState, CurrentPlayer);

            if (Board.PlayerTurnEnded)
            {
                NextPlayerTurn();
                Board.PlayerTurnEnded = false;
            }

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

            spriteBatch.DrawString(Textures.SpriteFont, $"Current player: {CurrentPlayer}", new Vector2(10, (Board.Height * 50) + 20), Color.Black);
            spriteBatch.DrawString(Textures.SpriteFont, $"Turn: {Turn}", new Vector2(10, (Board.Height * 50) + 40), Color.Black);
        }

        #endregion
    }
}
