using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            //При создании GameStateMachine создает инстансы BootstrapState и LoadLevelState.
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<LoadLevelState, LoadLevelState.Factory>();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}