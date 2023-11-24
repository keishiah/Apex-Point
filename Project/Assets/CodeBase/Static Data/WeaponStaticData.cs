using CodeBase.Logic.Weapon.WeaponTypes;
using UnityEngine;

namespace CodeBase.Static_Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "StaticData/Weapon", order = 0)]
    public class WeaponStaticData : ScriptableObject
    {
        public WeaponEnum weaponEnum;
        public int damage;
        public Color color;
    }
}