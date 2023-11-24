using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Weapon
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected WeaponEnum WeaponType;
        private IStaticDataService staticDataService;
        private readonly int color = Shader.PropertyToID("_Color");

        [Inject]
        void Construct(IStaticDataService staticDataService)
        {
            this.staticDataService = staticDataService;
        }

        private void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material
                .SetColor(color, staticDataService.GetWeaponData(WeaponType).color);
        }

        public void Shoot(Bullet bullet, Vector3 direction)
        {
            bullet.InitBullet(staticDataService.GetWeaponData(WeaponType).damage, direction,
                transform.position + transform.forward * 1.5f, staticDataService.GetWeaponData(WeaponType).color);
        }
    }
}