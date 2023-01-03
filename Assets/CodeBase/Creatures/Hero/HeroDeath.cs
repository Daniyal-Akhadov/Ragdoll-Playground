using UnityEngine;

namespace CodeBase.Creatures.Hero
{
    [RequireComponent(typeof(CreatureAnimator))]
    [RequireComponent(typeof(HeroHealth))]
    [RequireComponent(typeof(Movement))]
    public class HeroDeath : MonoBehaviour
    {
        private CreatureAnimator _animator;
        private HeroHealth _heroHealth;
        private Movement _movement;
        private bool _isDead;

        private void Awake()
        {
            _animator = GetComponent<CreatureAnimator>();
            _heroHealth = GetComponent<HeroHealth>();
            _movement = GetComponent<Movement>();
        }

        private void OnEnable()
        {
            _heroHealth.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _heroHealth.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_isDead == false && _heroHealth.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            _animator.PlayDeath();
            _movement.enabled = false;
        }
    }
}