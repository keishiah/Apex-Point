using UnityEngine;

namespace CodeBase.Logic.Enemy
{
    public class EnemyHit : MonoBehaviour
    {
        private TriggerObserver _triggerObserver;
        private EnemyDeath _enemyDeath;
        private int _damage;

        public void Construct(int damage)
        {
            _damage = damage;
        }

        private void Start()
        {
            _triggerObserver = GetComponent<TriggerObserver>();
            _triggerObserver.TriggerEnter += TriggerEnter;
            _enemyDeath = GetComponent<EnemyDeath>();
        }

        private void TriggerEnter(Collider obj)
        {
            if (obj.CompareTag("Player"))
            {
                obj.GetComponent<IHealth>().TakeDamage(_damage);
                _enemyDeath.Die();
            }
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEnter -= TriggerEnter;
        }
    }
}