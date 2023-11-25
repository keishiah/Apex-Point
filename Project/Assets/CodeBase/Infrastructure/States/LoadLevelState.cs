using CodeBase.Infrastructure.Factories;
using CodeBase.Services;
using CodeBase.Services.EnemySpawner;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IEnemySpawner _enemySpawner;

        public LoadLevelState(ISceneLoader sceneLoader, IGameFactory gameFactory,
            IEnemySpawner enemySpawner)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _enemySpawner = enemySpawner;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
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
            _gameFactory.CreateGameObjectsParent();
            _gameFactory.CreateTank(Vector3.zero);
            _gameFactory.CreateBulletPool();
            _enemySpawner.StartEnemySpawn();
        }

        public class Factory : PlaceholderFactory<LoadLevelState>
        {
        }
    }
}