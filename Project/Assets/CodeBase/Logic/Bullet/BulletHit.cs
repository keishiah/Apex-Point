using UnityEngine;

namespace CodeBase.Logic.Bullet
{
    public class BulletHit : MonoBehaviour
    {
        public TriggerObserver triggerObserver;
        private Bullet _bullet;

        private void Start()
        {
            triggerObserver = GetComponent<TriggerObserver>();
            triggerObserver.TriggerEnter += TriggerEnter;
            _bullet = GetComponent<Bullet>();
        }

        private void TriggerEnter(Collider obj)
        {
            gameObject.SetActive(false);
            obj.GetComponent<IHealth>().TakeDamage(_bullet.damage);
        }

        private void OnDestroy()
        {
            triggerObserver.TriggerEnter -= TriggerEnter;
        }
    }
}