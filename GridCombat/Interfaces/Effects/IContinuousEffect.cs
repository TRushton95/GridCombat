namespace GridCombat.Interfaces.Effects
{
    interface IContinuousEffect : IBaseEffect
    {
        int? Duration();

        void Expire();
    }
}
