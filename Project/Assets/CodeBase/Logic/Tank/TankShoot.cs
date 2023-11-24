using CodeBase.Logic.Weapon;
using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class TankShoot : MonoBehaviour
    {
        private WeaponSwapper weaponSwapper;
        private BulletPool bulletPool;

        private void Start()
        {
            weaponSwapper = GetComponent<WeaponSwapper>();
            bulletPool = GetComponent<BulletPool>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                weaponSwapper.GetActiveWeapon().Shoot(bulletPool.GetBullet(), transform.forward);
            }
        }
    }
}