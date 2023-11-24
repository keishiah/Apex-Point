using CodeBase.Logic.Weapon;
using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Static_Data;

namespace CodeBase.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        WeaponStaticData GetWeaponData(WeaponEnum weapon);
    }
}