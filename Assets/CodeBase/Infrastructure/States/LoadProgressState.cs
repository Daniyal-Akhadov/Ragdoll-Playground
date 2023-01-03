using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState
            (GameStateMachine stateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            Debug.Log(_progressService);
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgress();
            InitDefaultState();
            _stateMachine.Enter<LoadLevelState, string>(_progressService.Progress.CurrentLevel);
        }

        public void Exit()
        {
        }

        private void LoadProgress() =>
            _progressService.Progress =
                _saveLoadService.LoadProgress() ?? CreateNewProgress();

        private static PlayerProgress CreateNewProgress() =>
            new PlayerProgress(initialLevel: "Main");

        private void InitDefaultState() =>
            _progressService.Progress.HeroState.MaxHealth = 10;
    }
}