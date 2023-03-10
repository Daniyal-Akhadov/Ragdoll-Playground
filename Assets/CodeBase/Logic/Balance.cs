using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Balance : MonoBehaviour
    {
        [SerializeField] private float _targetRotation;
        [SerializeField] private float _force;
        [SerializeField] private GettingUp _gettingUp;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_gettingUp.CanGetUp == true)
            {
                _rigidbody.MoveRotation
                (
                    Mathf.LerpAngle
                    (
                        _rigidbody.rotation,
                        _targetRotation,
                        _force * Time.fixedDeltaTime
                    )
                );
            }
        }
    }
}