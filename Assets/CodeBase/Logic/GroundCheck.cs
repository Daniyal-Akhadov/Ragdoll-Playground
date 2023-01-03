using UnityEngine;

namespace CodeBase.Logic
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        
        public bool IsGround { get; private set; }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.IsLayerIn(_groundLayer))
                IsGround = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.IsLayerIn(_groundLayer))
                IsGround = false;
        }
    }
}