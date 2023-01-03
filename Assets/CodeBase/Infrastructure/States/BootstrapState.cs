using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ServiceLocator _services;

        public BootstrapState(GameStateMachine stateMachine, ServiceLocator services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterService();
        }

        public void Exit()
        {
        }

        private void RegisterService()
        {
            // _services.RegisterSingle<IGameFactory>(new GameFactory())
        }
    }
}