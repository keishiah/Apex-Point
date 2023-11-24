using UnityEngine;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [HideInInspector] public float speed = 1f;

        public Transform heroTransform;

        public void Construct(Transform heroTransform, float speed)
        {
            this.heroTransform = heroTransform;
            this.speed = speed;
        }


        private void Update()
        {
            Vector3 direction = heroTransform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}