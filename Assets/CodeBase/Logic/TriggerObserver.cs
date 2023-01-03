using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class TriggerObserver : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;

        public event Action TriggerEnter;
        public event Action TriggerExit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.IsLayerIn(_layer))
            {
                TriggerEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.IsLayerIn(_layer))
            {
                TriggerExit?.Invoke();
            }
        }
    }
}