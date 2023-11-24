using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHit : MonoBehaviour
    {
        private TriggerObserver triggerObserver;
        private EnemyDeath enemyDeath;
        public int damage;

        public void Construct(int damage)
        {
            this.damage = damage;
        }

        private void Start()
        {
            triggerObserver = GetComponent<TriggerObserver>();
            triggerObserver.TriggerEnter += TriggerEnter;
            enemyDeath = GetComponent<EnemyDeath>();
        }

        private void TriggerEnter(Collider obj)
        {
            if (obj.CompareTag("Player"))
            {
                obj.GetComponent<IHealth>().TakeDamage(damage);
                enemyDeath.Die();
            }
        }

        private void OnDestroy()
        {
            triggerObserver.TriggerEnter -= TriggerEnter;
        }
    }
}