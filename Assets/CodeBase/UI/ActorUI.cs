using CodeBase.Creatures.Hero;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;

        private HeroHealth _heroHealth;

        private void OnDestroy()
        {
            _heroHealth.HealthChanged -= UpdateHealthBar;
        }

        public void Construct(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.HealthChanged += UpdateHealthBar;
        }

        private void UpdateHealthBar()
        {
            _healthBar.SetValue(_heroHealth.Current, _heroHealth.MaxHealth);
        }
    }
}