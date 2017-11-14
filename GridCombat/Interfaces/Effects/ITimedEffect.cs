namespace GridCombat.Interfaces.Effects
{
    interface ITimedEffect : IBaseEffect
    {
        int Duration { get; set; }

        void Expire();
    }
}
