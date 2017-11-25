namespace GridCombat
{
    abstract class BaseInstance
    {
        protected static Board Board => Board.Instance;

        protected static Textures Textures => Textures.Instance;
    }
}
