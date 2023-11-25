using System;
using System.Collections;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Logic.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Services.EnemySpawner
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IGameFactory _gameFactory;
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly EnemyEnum[] _enumValues = (EnemyEnum[])Enum.GetValues(typeof(EnemyEnum));

        private int _enemyCount;
        private int _maxEnemyCount = 10;

        private float _planeWidth = 76;
        private float _planeLength = 52;
        private readonly WaitForSeconds _waitTime = new(2f);

        public EnemySpawner(IGameFactory gameFactory, ICoroutineRunner coroutineRunner)
        {
            _gameFactory = gameFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void StartEnemySpawn()
        {
            _enemyCount = 0;
            _coroutineRunner.StartCoroutine(EnemySpawnRoutine());
        }

        private IEnumerator EnemySpawnRoutine()
        {
            while (true)
            {
                if (_enemyCount < _maxEnemyCount)
                    SpawnEnemy();
                yield return _waitTime;
            }
        }

        private void SpawnEnemy()
        {
            _gameFactory.CreateEnemy(GetRandomPosition(), GetRandomEnemy());
            _enemyCount++;
        }

        public void OnEnemyDestroyed() => _enemyCount--;

        private EnemyEnum GetRandomEnemy()
        {
            int randomIndex = Random.Range(0, _enumValues.Length);
            return _enumValues[randomIndex];
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 randomPointOnPerimeter = GetRandomPointOnPerimeter(Vector3.zero, _planeWidth, _planeLength);
            return randomPointOnPerimeter;
        }

        Vector3 GetRandomPointOnPerimeter(Vector3 position, float width, float length)
        {
            int side = Random.Range(0, 4);

            float randomX = 0f;
            float randomY = 0f;

            switch (side)
            {
                case 0:
                    randomX = Random.Range(position.x - width / 2f, position.x + width / 2f);
                    randomY = position.z + length / 2f;
                    break;
                case 1:
                    randomX = position.x + width / 2f;
                    randomY = Random.Range(position.z - length / 2f, position.z + length / 2f);
                    break;
                case 2:
                    randomX = Random.Range(position.x - width / 2f, position.x + width / 2f);
                    randomY = position.z - length / 2f;
                    break;
                case 3:
                    randomX = position.x - width / 2f;
                    randomY = Random.Range(position.z - length / 2f, position.z + length / 2f);
                    break;
            }

            return new Vector3(randomX, randomY, 0);
        }
    }
}