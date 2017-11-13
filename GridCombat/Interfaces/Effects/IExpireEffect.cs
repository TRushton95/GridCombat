namespace GridCombat.Interfaces.Effects
{
    interface IExpireEffect : IBaseEffect
    {
        int Duration { get; set; }

        void Expire();
    }
}
