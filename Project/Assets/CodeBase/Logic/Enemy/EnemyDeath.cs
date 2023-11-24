using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyHealth health;
        private IEnemySpawner enemySpawner;

        [Inject]
        void Construct(IEnemySpawner enemySpawner)
        {
            this.enemySpawner = enemySpawner;
        }

        private void Start()
        {
            health = GetComponent<EnemyHealth>();
            health.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (health.Current <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            enemySpawner.OnEnemyDestroyed();
            Destroy(gameObject);
        }
    }
}