using CodeBase.Infrastructure.Factories;
using CodeBase.Logic.Weapon;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Tank
{
    public class TankShoot : MonoBehaviour
    {
        private WeaponSwapper _weaponSwapper;
        private IGameFactory _gameFactory;

        [Inject]
        void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _weaponSwapper = GetComponent<WeaponSwapper>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                _weaponSwapper.GetActiveWeapon().Shoot(_gameFactory.GetBullet(), transform.forward);
            }
        }
    }
}