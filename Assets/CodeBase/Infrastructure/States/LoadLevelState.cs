using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        private const string InitialPointTag = "InitialPoint";

        public LoadLevelState
        (
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            IGameFactory gameFactory
        )
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
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
            _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));
            _gameFactory.CreateHud();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}