using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Enemy;
using CodeBase.Logic.Weapon.WeaponTypes;
using CodeBase.Static_Data;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string WeaponStaticDataPath = "Static Data/Weapons";
        private const string EnemyStaticDataPath = "Static Data/Enemies";

        private Dictionary<WeaponEnum, WeaponStaticData> monsters;
        private Dictionary<EnemyEnum, EnemyStaticData> enemies;

        public void Initialize()
        {
            monsters = Resources
                .LoadAll<WeaponStaticData>(WeaponStaticDataPath)
                .ToDictionary(x => x.weaponEnum, x => x);
            enemies = Resources
                .LoadAll<EnemyStaticData>(EnemyStaticDataPath)
                .ToDictionary(x => x.enemyEnum, x => x);
        }

        public WeaponStaticData GetWeaponData(WeaponEnum weapon) =>
            monsters.TryGetValue(weapon, out WeaponStaticData staticData)
                ? staticData
                : throw new Exception($"WeaponStaticData dictionary doesnt have {weapon}");

        public EnemyStaticData GetEnemyData(EnemyEnum enemy) =>
            enemies.TryGetValue(enemy, out EnemyStaticData staticData)
                ? staticData
                : throw new Exception($"EnemyStaticData dictionary doesnt have {enemy}");
    }
}