using UnityEngine;

namespace CodeBase.Logic
{
    public class BulletHit : MonoBehaviour
    {
        public TriggerObserver triggerObserver;
        private Bullet bullet;

        private void Start()
        {
            triggerObserver = GetComponent<TriggerObserver>();
            triggerObserver.TriggerEnter += TriggerEnter;
            bullet = GetComponent<Bullet>();
        }

        private void TriggerEnter(Collider obj)
        {
            gameObject.SetActive(false);
            obj.GetComponent<IHealth>().TakeDamage(bullet.damage);
        }

        private void OnDestroy()
        {
            triggerObserver.TriggerEnter -= TriggerEnter;
        }
    }
}