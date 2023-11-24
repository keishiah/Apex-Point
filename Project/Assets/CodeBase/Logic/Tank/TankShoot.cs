using CodeBase.Infrastructure.Factories;
using CodeBase.Logic.Weapon;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Tank
{
    public class TankShoot : MonoBehaviour
    {
        private WeaponSwapper weaponSwapper;
        private IGameFactory gameFactory;

        [Inject]
        void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Start()
        {
            weaponSwapper = GetComponent<WeaponSwapper>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                weaponSwapper.GetActiveWeapon().Shoot(gameFactory.GetBullet(), transform.forward);
            }
        }
    }
}