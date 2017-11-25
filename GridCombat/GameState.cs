namespace GridCombat
{
    #region Usings

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    class GameState : BaseInstance
    {
        #region Properties

        public int CurrentPlayer
        {
            get;
            set;
        }

        public int Turn
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void EndTurn()
        {

        }

        public void LoadTextures(ContentManager contentManager)
        {
            Textures.Initialise(contentManager);
        }

        public void StartGame()
        {
            Board.Generate();
            CurrentPlayer = 0;
            Turn = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Board.Draw(spriteBatch);
        }

        #endregion
    }
}
