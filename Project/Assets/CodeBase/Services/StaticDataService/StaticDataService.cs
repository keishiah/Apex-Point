using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Logic.Enemy;
using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Static_Data;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string WeaponStaticDataPath = "Static Data/Weapons";
        private const string EnemyStaticDataPath = "Static Data/Enemies";

        private Dictionary<WeaponEnum, WeaponStaticData> _monsters;
        private Dictionary<EnemyEnum, EnemyStaticData> _enemies;

        public void Initialize()
        {
            _monsters = Resources
                .LoadAll<WeaponStaticData>(WeaponStaticDataPath)
                .ToDictionary(x => x.weaponEnum, x => x);
            _enemies = Resources
                .LoadAll<EnemyStaticData>(EnemyStaticDataPath)
                .ToDictionary(x => x.enemyEnum, x => x);
        }

        public WeaponStaticData GetWeaponData(WeaponEnum weapon) =>
            _monsters.TryGetValue(weapon, out WeaponStaticData staticData)
                ? staticData
                : throw new Exception($"WeaponStaticData dictionary doesnt have {weapon}");

        public EnemyStaticData GetEnemyData(EnemyEnum enemy) =>
            _enemies.TryGetValue(enemy, out EnemyStaticData staticData)
                ? staticData
                : throw new Exception($"EnemyStaticData dictionary doesnt have {enemy}");
    }
}