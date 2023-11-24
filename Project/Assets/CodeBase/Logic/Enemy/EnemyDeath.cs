using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth health;
        public event Action OnEnemyDied;

        private void Start()
        {
            health.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (health.Current <= 0)
                Die();
        }

        private void Die()
        {
            OnEnemyDied?.Invoke();
        }


    }
}