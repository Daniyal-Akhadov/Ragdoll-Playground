using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Creatures.Hero
{
    public class StrongCollisionAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float _targetForceImpact = 2000f;
        [SerializeField] private float _attackCooldown = 0.5f;

        private float _timer;
        private bool _canAttack;

        private const int MinForceImpact = 1500;

        private bool CooldownIsUp => _timer <= 0;

        private void OnValidate()
        {
            if (_targetForceImpact < MinForceImpact)
            {
                _targetForceImpact = MinForceImpact;
            }
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (CooldownIsUp)
                _canAttack = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_canAttack == false)
                return;

            if (collision.relativeVelocity.sqrMagnitude > _targetForceImpact 
                && collision.transform.parent.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(damage);
                OnAttack();
            }
        }

        private void OnAttack()
        {
            _canAttack = false;
            _timer = _attackCooldown;
        }
    }
}