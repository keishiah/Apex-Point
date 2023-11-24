using CodeBase.Services.StaticDataService;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly IStaticDataService staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService)
        {
            this.staticDataService = staticDataService;
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            InitServices();
            gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.StartGameScene);
        }

        private void InitServices()
        {
            staticDataService.Initialize();
        }

        public void Exit()
        {
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}