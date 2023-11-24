using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstraperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindLoadingCurtain();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();

            BindUIFactory();

            BindPlayerProgressService();

            BindSaveLoadService();
        }

        private void BindStaticDataService() =>
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

        private void BindGameBootstraperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootstraper);
        }
        
        private void BindSaveLoadService()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
        }

        private void BindPlayerProgressService()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerProgressService>()
                .AsSingle();
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

        private void BindLoadingCurtain() =>
            Container.Bind<ILoadingCurtain>().To<LoadingCurtain>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CurtainPath).AsSingle();

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