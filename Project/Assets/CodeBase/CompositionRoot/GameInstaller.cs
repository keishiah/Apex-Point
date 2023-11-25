using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Services.EnemySpawner;
using CodeBase.Services.GameOver;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.Factories;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstrapperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();

            BindUIFactory();

            BindEnemySpawner();

            BindGameOverService();
        }

        private void BindGameOverService()
        {
            Container.Bind<IGameOver>().To<GameOver>().AsSingle();
        }

        private void BindEnemySpawner()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
        }

        private void BindStaticDataService() =>
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

        private void BindGameBootstrapperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootsTrapper);
        }

        private void BindGameFactory()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>().AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunnerPath)
                .AsSingle();
        }

        private void BindSceneLoader() =>
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }
    }
}