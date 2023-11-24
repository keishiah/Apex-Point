using CodeBase.Logic.Weapon;
using CodeBase.Logic.Weapon.WeaponTypes;
using UnityEngine;

namespace CodeBase.Static_Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "StaticData/Weapon", order = 0)]
    public class WeaponStaticData : ScriptableObject
    {
        public WeaponEnum WeaponEnum;
        public int Damage;
        public Color Color;
    }
}