using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth, IArmor
    {
        private float current;
        private float max;
        private float armor;
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

        public float Armor
        {
            get => 1 - armor / 100;
            set => armor = value;
        }

        public void TakeDamage(float damage)
        {
            Current -= damage * Armor;
            HealthChanged?.Invoke();
        }

        private void ResetHealth()
        {
            Current = Max;
            HealthChanged?.Invoke();
        }
    }
}