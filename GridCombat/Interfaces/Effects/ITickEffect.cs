namespace GridCombat.Interfaces.Effects
{
    interface ITickEffect : IBaseEffect
    {
        int Duration { get; set; }

        void Tick();
    }
}
