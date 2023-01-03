using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at)
        {
            return _assets.Instantiate(AssetsPath.Hero, at.transform.position);
        }

        public void CreateHud()
        {
            _assets.Instantiate(AssetsPath.Hud);
        }
    }
}