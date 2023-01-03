using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _bootstrapperPrefab;

        private void Awake()
        {
            GameBootstrapper otherBootstrapper = FindObjectOfType<GameBootstrapper>();

            if (otherBootstrapper == null)
                Instantiate(_bootstrapperPrefab);
        }
    }
}