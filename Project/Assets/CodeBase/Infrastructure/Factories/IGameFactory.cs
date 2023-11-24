using CodeBase.Enemy;
using CodeBase.Logic;
using CodeBase.UI.HUD;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        void Cleanup();
        GameObject CreateTank(Vector3 position);
        void CreateParent();
        GameObject CreateEnemy(Vector3 position, EnemyEnum enemyType);
        void CreateBulletPool();
        Bullet GetBullet();
    }
}