using UnityEngine;

namespace CodeBase.Logic
{
    public static class GameObjectExtensions
    {
        public static bool IsLayerIn(this GameObject gameObject, LayerMask layer)
        {
            return (layer.value & (1 << gameObject.layer)) != 0;
        }
    }
}