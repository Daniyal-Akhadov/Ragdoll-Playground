using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Creatures.Hero
{
    [RequireComponent(typeof(CreatureAnimator))]
    public class HeroHealth : MonoBehaviour, IProgressReader, IHealth
    {
        private CreatureAnimator _animator;
        private State _state;

        public event Action HealthChanged;

        public int Current { get; private set; }

        public int MaxHealth { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<CreatureAnimator>();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            MaxHealth = progress.HeroState.MaxHealth;
            Current = MaxHealth;
            HealthChanged?.Invoke();
        }

        public void TakeDamage(int value)
        {
            if (Current <= 0f)
                return;

            Current -= value;
            HealthChanged?.Invoke();
        }
    }
}