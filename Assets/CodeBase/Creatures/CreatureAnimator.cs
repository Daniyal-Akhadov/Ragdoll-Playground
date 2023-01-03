using UnityEngine;

namespace CodeBase.Creatures
{
    public class CreatureAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int IsMovingRight = Animator.StringToHash("IsMovingRight");
        private static readonly int IsMovingLeft = Animator.StringToHash("IsMovingLeft");
        private static readonly int IsStanding = Animator.StringToHash("IsStanding");
        private static readonly int Die = Animator.StringToHash("Die");

        public void PlayMovementRight() =>
            _animator.SetBool(IsMovingRight, true);

        public void PlayMovementLeft() =>
            _animator.SetBool(IsMovingLeft, true);

        public void PlayIdle() =>
            _animator.SetBool(IsStanding, true);

        public void PlayDeath() => 
            _animator.SetTrigger(Die);
    }
}