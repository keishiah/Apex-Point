using UnityEngine;

namespace CodeBase.Logic
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public int damage;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float speed = 10f;

        private void Update()
        {
            MoveForward();
            DeactivateBullet();
        }

        public void InitBullet(int damage, Vector3 direction, Vector3 position)
        {
            this.damage = damage;
            this.direction = direction;
            transform.position = position;
        }

        private void MoveForward()
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = currentPosition + direction * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        private void DeactivateBullet()
        {
            if (transform.position.x > 50 || transform.position.x < -50 || transform.position.y > 50 ||
                transform.position.y < -50)
                gameObject.SetActive(false);
        }
    }
}