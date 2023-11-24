using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Logic.Weapon;
using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Static_Data;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string WeaponStaticDataPath = "Static Data/Weapons";
        private Dictionary<WeaponEnum, WeaponStaticData> _monsters;

        public void Initialize()
        {
            _monsters = Resources
                .LoadAll<WeaponStaticData>(WeaponStaticDataPath)
                .ToDictionary(x => x.WeaponEnum, x => x);
        }

        public WeaponStaticData GetWeaponData(WeaponEnum weapon) =>
            _monsters.TryGetValue(weapon, out WeaponStaticData staticData)
                ? staticData
                : throw new Exception($"WeaponStaticData dictionary doesnt have {weapon}");
    }
}