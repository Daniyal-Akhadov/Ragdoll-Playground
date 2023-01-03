using CodeBase.Creatures.Hero;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        private const string InitialPointTag = "InitialPoint";

        public LoadLevelState
        (
            GameStateMachine stateMachine,
            IPersistentProgressService progressService,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            IGameFactory gameFactory
        )
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.LoadScene(sceneName, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
        }

        private void InitGameWorld()
        {
            GameObject hero = InitHero();
            InitHud(hero.GetComponent<HeroHealth>());
            _stateMachine.Enter<GameLoopState>();
        }

        private GameObject InitHero() =>
            _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));

        private void InitHud(HeroHealth hero)
        {
            GameObject hud = _gameFactory.CreateHud();
            hud.GetComponentInChildren<ActorUI>().Construct(hero);
        }

        private void InformProgressReaders()
        {
            foreach (IProgressReader reader in _gameFactory.ProgressReaders)
            {
                reader.LoadProgress(_progressService.Progress);
            }
        }
    }
}