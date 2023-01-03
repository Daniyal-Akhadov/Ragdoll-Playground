using UnityEngine;

namespace CodeBase.Logic
{
    public class IgnoreCollision : MonoBehaviour
    {
        private void Awake()
        {
            Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

            foreach (Collider2D first in colliders)
            {
                foreach (Collider2D second in colliders)
                {
                    Physics2D.IgnoreCollision(first, second);
                }
            }
        }
    }
}