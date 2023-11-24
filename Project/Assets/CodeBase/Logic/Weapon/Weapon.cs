using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Weapon
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected IStaticDataService StaticDataService;

        protected WeaponEnum weaponType;

        [Inject]
        void Construct(IStaticDataService staticDataService)
        {
            StaticDataService = staticDataService;
        }

        private void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material
                .SetColor("_Color", StaticDataService.GetWeaponData(weaponType).Color);
        }

        public void Shoot()
        {
            print($"shoot with {StaticDataService.GetWeaponData(weaponType).Damage}");
        }
    }
}