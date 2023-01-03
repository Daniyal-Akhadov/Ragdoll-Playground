using System.Collections;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Creatures
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _leftLeg;
        [SerializeField] private Rigidbody2D _rightLeg;
        [SerializeField] private float _stepForce = 5f;
        [SerializeField] private float _stepBreakTime = 0.5f;
        [SerializeField] private GettingUp _gettingUp;

        private CreatureAnimator _animator;
        private WaitForSeconds _stepWaitForSeconds;
        private Coroutine _movementCoroutine;

        private void Awake()
        {
            _stepWaitForSeconds = new WaitForSeconds(_stepBreakTime);
        }

        private void Update()
        {
            if (_gettingUp.CanGetUp == true && _movementCoroutine == null)
                _movementCoroutine = StartCoroutine(Move(Vector2.right));
        }

        private IEnumerator Move(Vector2 direction)
        {
            AddForce(_rightLeg, direction);
            yield return _stepWaitForSeconds;
            AddForce(_leftLeg, direction);
            _movementCoroutine = null;
        }

        private void AddForce(Rigidbody2D rigidbody, Vector2 direction)
        {
            rigidbody.AddForce(direction * (_stepForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
    }
}