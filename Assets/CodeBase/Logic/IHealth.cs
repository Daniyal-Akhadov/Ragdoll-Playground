using System;

namespace CodeBase.Logic
{
    public interface IHealth
    {
        int Current { get; }
        
        int MaxHealth { get; }

        event Action HealthChanged;
        
        void TakeDamage(int value);
    }
}