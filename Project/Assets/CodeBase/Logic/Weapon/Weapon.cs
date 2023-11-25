using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Weapon
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected WeaponEnum WeaponType;
        private IStaticDataService _staticDataService;
        private readonly int _color = Shader.PropertyToID("_Color");

        [Inject]
        void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        private void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material
                .SetColor(_color, _staticDataService.GetWeaponData(WeaponType).color);
        }

        public void Shoot(Bullet.Bullet bullet, Vector3 direction)
        {
            bullet.InitBullet(_staticDataService.GetWeaponData(WeaponType).damage, direction,
                transform.position + transform.forward * 1.5f, _staticDataService.GetWeaponData(WeaponType).color);
        }
    }
}