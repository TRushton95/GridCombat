namespace GridCombat
{
    #region Usings

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    partial class GameState : BaseInstance
    {
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
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Board.Draw(spriteBatch);
        }

        #endregion
    }
}
