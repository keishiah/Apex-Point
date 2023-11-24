using System;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class BulletPool : MonoBehaviour
    {
        public Bullet bulletPrefab;
        public Transform poolParent;
        private Pooler<Bullet> bulletPool;

        private void Start()
        {
            bulletPool = new Pooler<Bullet>(bulletPrefab, 5, poolParent);
        }

        public Bullet GetBullet()
        {
            return bulletPool.GetFreeElement();
        }
    }
}