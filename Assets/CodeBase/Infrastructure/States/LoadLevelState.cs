using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly ServiceLocator _services;

        private const string InitialPointTag = "InitialPoint";

        public LoadLevelState
        (
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            ServiceLocator services
        )
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _services = services;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.LoadScene(sceneName, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded()
        {
            Transform initialPoint = GameObject.FindWithTag(InitialPointTag).transform;
            Instantiate(AssetsPath.Hero, at: initialPoint.position);
            Instantiate(AssetsPath.Hud);
            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector2 at)
        {
            GameObject prefab = Instantiate(path);
            prefab.transform.position = at;
            return prefab;
        }
    }

    public static class AssetsPath
    {
        public const string Hero = "Hero/Hero";
        public const string Hud = "Hud/Hud";
    }
}