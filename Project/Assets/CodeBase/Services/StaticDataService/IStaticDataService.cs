using CodeBase.Logic.Enemy;
using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Static_Data;

namespace CodeBase.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        WeaponStaticData GetWeaponData(WeaponEnum weapon);
        EnemyStaticData GetEnemyData(EnemyEnum enemy);
    }
}