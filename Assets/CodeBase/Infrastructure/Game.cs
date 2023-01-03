using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; }

        public Game()
        {
            StateMachine = new GameStateMachine(new ServiceLocator());
        }
    }
}