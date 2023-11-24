using System;
using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class TankHealth : MonoBehaviour, IHealth
    {
        public float armor;
        public float max;
        private float current;
        public event Action HealthChanged;

        private void Start()
        {
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

        public float Armor => 1 - armor / 100;

        public void TakeDamage(float damage)
        {
            Current -= damage * Armor;
            HealthChanged?.Invoke();
        }

        public void ResetHealth()
        {
            Current = Max;
            HealthChanged?.Invoke();
        }
    }
}