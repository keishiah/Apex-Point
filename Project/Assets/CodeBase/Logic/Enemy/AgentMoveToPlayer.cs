using UnityEngine;

namespace CodeBase.Logic.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private float _speed = 1f;
        private Transform _heroTransform;

        public void Construct(Transform heroTransform, float speed)
        {
            _heroTransform = heroTransform;
            _speed = speed;
        }

        private void Update()
        {
            Vector3 direction = _heroTransform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * (_speed * Time.deltaTime));
        }
    }
}