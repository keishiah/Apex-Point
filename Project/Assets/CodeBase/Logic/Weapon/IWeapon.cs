using UnityEngine;

namespace CodeBase.Logic.Weapon
{
    public interface IWeapon
    {
        void Shoot(Bullet bullet, Vector3 direction);
    }
}