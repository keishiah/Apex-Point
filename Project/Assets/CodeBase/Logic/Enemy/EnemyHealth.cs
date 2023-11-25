using System;
using UnityEngine;

namespace CodeBase.Logic.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth, IArmor
    {
        private float _current;
        private float _max;
        private float _armor;
        public event Action HealthChanged;

        public void Construct(float max, int armor)
        {
            Max = max;
            Armor = armor;
            ResetHealth();
        }

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public float Armor
        {
            get => 1 - _armor / 100;
            set => _armor = value;
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