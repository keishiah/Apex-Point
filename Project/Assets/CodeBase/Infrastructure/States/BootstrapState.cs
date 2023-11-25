using CodeBase.Services.StaticDataService;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            InitServices();
            _gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.StartGameScene);
        }

        private void InitServices()
        {
            _staticDataService.Initialize();
        }

        public void Exit()
        {
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}