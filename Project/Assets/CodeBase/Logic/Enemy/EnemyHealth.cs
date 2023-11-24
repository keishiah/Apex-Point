using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth, IArmor
    {
        private float current;
        private float max;
        private int armor;

        public event Action HealthChanged;

        public void Construct(float max, int armor)
        {
            Max = max;
            Armor = armor;
            ResetHealth();
        }

        public float Current
        {
            get => current;
            set => current = value;
        }

        public float Max
        {
            get => max;
            set => max = value;
        }

        public int Armor
        {
            get => armor;
            set => armor = value;
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;
            HealthChanged?.Invoke();
        }

        public void ResetHealth()
        {
            Current = Max;
            HealthChanged?.Invoke();
        }
    }
}