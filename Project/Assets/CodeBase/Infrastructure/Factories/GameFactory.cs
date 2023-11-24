using CodeBase.Enemy;
using CodeBase.Logic;
using CodeBase.Services;
using CodeBase.Services.StaticDataService;
using CodeBase.Static_Data;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private const string HeroPrefabPath = "Gameobjects/Tank";
        private const string BulletPrefabPath = "Gameobjects/Bullet";
        private readonly IStaticDataService staticDataService;
        private readonly DiContainer diContainer;

        private Transform gameObjectsParent;
        private GameObject tank;
        private Pooler<Bullet> bulletPool;


        public GameFactory(IStaticDataService staticDataService, DiContainer diContainer)
        {
            this.staticDataService = staticDataService;
            this.diContainer = diContainer;
        }

        public void CreateParent()
        {
            gameObjectsParent = new GameObject("GameObjectsParent").transform;
        }

        public GameObject CreateTank(Vector3 position)
        {
            GameObject tankPrefab = diContainer.InstantiatePrefabResource(HeroPrefabPath, gameObjectsParent);
            tankPrefab.transform.SetPositionAndRotation(position, Quaternion.Euler(90, -90, 90));
            tank = tankPrefab;
            return tankPrefab;
        }

        public GameObject CreateEnemy(Vector3 position, EnemyEnum enemyType)
        {
            EnemyStaticData enemyData = staticDataService.GetEnemyData(enemyType);

            var enemy = diContainer.InstantiatePrefab(enemyData.enemyPrefab, position,
                Quaternion.identity, gameObjectsParent);
            enemy.GetComponent<AgentMoveToPlayer>().Construct(tank.transform, enemyData.moveSpeed);
            enemy.GetComponent<EnemyHealth>().Construct(enemyData.health, enemyData.armor);
            enemy.GetComponent<EnemyHit>().Construct(enemyData.damage);
            return enemy;
        }

        public void CreateBulletPool()
        {
            bulletPool = new Pooler<Bullet>(Resources.Load<Bullet>(BulletPrefabPath), 5);
        }

        public Bullet GetBullet()
        {
            return bulletPool.GetFreeElement();
        }

        public void Cleanup()
        {
        }
    }
}