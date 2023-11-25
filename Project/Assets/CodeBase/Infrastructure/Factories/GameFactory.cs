using CodeBase.Logic;
using CodeBase.Logic.Bullet;
using CodeBase.Logic.Enemy;
using CodeBase.Services;
using CodeBase.Services.StaticDataService;
using CodeBase.Static_Data;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private const string HeroPrefabPath = InfrastructureAssetPath.TankPrefabPath;
        private const string BulletPrefabPath = InfrastructureAssetPath.BulletPrefabPath;
        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _diContainer;

        private Transform _gameObjectsParent;
        private GameObject _tank;
        private Pooler<Bullet> _bulletPool;


        public GameFactory(IStaticDataService staticDataService, DiContainer diContainer)
        {
            _staticDataService = staticDataService;
            _diContainer = diContainer;
        }

        public void CreateGameObjectsParent()
        {
            _gameObjectsParent = new GameObject("GameObjectsParent").transform;
        }

        public GameObject CreateTank(Vector3 position)
        {
            GameObject tankPrefab = _diContainer.InstantiatePrefabResource(HeroPrefabPath, _gameObjectsParent);
            tankPrefab.transform.SetPositionAndRotation(position, Quaternion.Euler(90, -90, 90));
            _tank = tankPrefab;
            return tankPrefab;
        }

        public GameObject CreateEnemy(Vector3 position, EnemyEnum enemyType)
        {
            EnemyStaticData enemyData = _staticDataService.GetEnemyData(enemyType);

            var enemy = _diContainer.InstantiatePrefab(enemyData.enemyPrefab, position,
                Quaternion.identity, _gameObjectsParent);
            enemy.GetComponent<AgentMoveToPlayer>().Construct(_tank.transform, enemyData.moveSpeed);
            enemy.GetComponent<EnemyHealth>().Construct(enemyData.health, enemyData.armor);
            enemy.GetComponent<EnemyHit>().Construct(enemyData.damage);
            return enemy;
        }

        public void CreateBulletPool()
        {
            _bulletPool = new Pooler<Bullet>(Resources.Load<Bullet>(BulletPrefabPath), 5);
        }

        public Bullet GetBullet()
        {
            return _bulletPool.GetFreeElement();
        }

        public void Cleanup()
        {
        }
    }
}