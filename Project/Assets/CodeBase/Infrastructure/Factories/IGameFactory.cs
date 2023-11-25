using CodeBase.Logic.Bullet;
using CodeBase.Logic.Enemy;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        void Cleanup();
        GameObject CreateTank(Vector3 position);
        void CreateGameObjectsParent();
        GameObject CreateEnemy(Vector3 position, EnemyEnum enemyType);
        void CreateBulletPool();
        Bullet GetBullet();
    }
}