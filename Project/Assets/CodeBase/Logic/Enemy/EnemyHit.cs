using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHit : MonoBehaviour
    {
        private TriggerObserver triggerObserver;

        private void Start()
        {
            triggerObserver = GetComponent<TriggerObserver>();
            triggerObserver.TriggerEnter += TriggerEnter;
        }

        private void TriggerEnter(Collider obj)
        {
            gameObject.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            triggerObserver.TriggerEnter -= TriggerEnter;
        }
    }
}