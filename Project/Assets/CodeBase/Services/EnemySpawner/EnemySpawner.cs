using System;
using System.Collections;
using CodeBase.Enemy;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Services
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IGameFactory gameFactory;
        private readonly ICoroutineRunner coroutineRunner;

        readonly EnemyEnum[] enumValues = (EnemyEnum[])Enum.GetValues(typeof(EnemyEnum));

        private int enemyCount;
        private int maxEnemyCount = 10;

        private float planeWidth = 76;
        private float planeLength = 52;
        private readonly WaitForSeconds waitTime = new WaitForSeconds(2f);

        public EnemySpawner(IGameFactory gameFactory, ICoroutineRunner coroutineRunner)
        {
            this.gameFactory = gameFactory;
            this.coroutineRunner = coroutineRunner;
        }

        public void StartEnemySpawn()
        {
            enemyCount = 0;
            coroutineRunner.StartCoroutine(EnemySpawnRoutine());
        }

        private IEnumerator EnemySpawnRoutine()
        {
            while (true)
            {
                if (enemyCount < maxEnemyCount)
                    SpawnEnemy();
                yield return waitTime;
            }
        }

        private void SpawnEnemy()
        {
            gameFactory.CreateEnemy(GetRandomPosition(), GetRandomEnemy());
            enemyCount++;
        }

        public void OnEnemyDestroyed() => enemyCount--;

        private EnemyEnum GetRandomEnemy()
        {
            int randomIndex = Random.Range(0, enumValues.Length);
            return enumValues[randomIndex];
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 randomPointOnPerimeter = GetRandomPointOnPerimeter(Vector3.zero, planeWidth, planeLength);
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