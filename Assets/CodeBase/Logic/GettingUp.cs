using UnityEngine;

namespace CodeBase.Logic
{
    public class GettingUp : MonoBehaviour
    {
        [SerializeField] private float _cooldownAfterFalling = 2f;
        [SerializeField] private GroundCheck _groundCheck;
        
        private float _timer;

        public bool CanGetUp { get; private set; }

        private void Update()
        {
            if (_groundCheck.IsGround == true)
            {
                _timer -= Time.deltaTime;

                if (_timer <= 0f)
                    CanGetUp = true;
            }
            else
            {
                _timer = _cooldownAfterFalling;
                CanGetUp = false;
            }
        }
    }
}