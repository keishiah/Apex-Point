using CodeBase.Services;
using CodeBase.Services.EnemySpawner;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyHealth _health;
        private IEnemySpawner _enemySpawner;

        [Inject]
        void Construct(IEnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        private void Start()
        {
            _health = GetComponent<EnemyHealth>();
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_health.Current <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            _enemySpawner.OnEnemyDestroyed();
            Destroy(gameObject);
        }
    }
}