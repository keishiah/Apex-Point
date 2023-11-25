using UnityEngine;

namespace CodeBase.Logic.Weapon
{
    public interface IWeapon
    {
        void Shoot(Bullet.Bullet bullet, Vector3 direction);
    }
}