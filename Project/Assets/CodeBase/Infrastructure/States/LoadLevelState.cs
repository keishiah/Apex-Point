using CodeBase.Infrastructure.Factories;
using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly ISceneLoader sceneLoader;
        private readonly IGameFactory gameFactory;
        private readonly IEnemySpawner enemySpawner;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory,
            IEnemySpawner enemySpawner)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.gameFactory = gameFactory;
            this.enemySpawner = enemySpawner;
        }

        public void Enter(string sceneName)
        {
            sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitGame();
        }

        private void InitGame()
        {
            gameFactory.CreateParent();
            gameFactory.CreateTank(Vector3.zero);
            gameFactory.CreateBulletPool();
            enemySpawner.StartEnemySpawn();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}