using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.Static_Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy", order = 1)]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyEnum enemyEnum;
        public GameObject enemyPrefab;
        public float health;
        public int armor;
        public float moveSpeed;
    }
}