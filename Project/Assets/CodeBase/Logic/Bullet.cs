using UnityEngine;

namespace CodeBase.Logic
{
    public class Bullet : MonoBehaviour
    {
        public int damage;
        public Vector3 direction;

        public float speed = 10f; // Скорость движения пули


        private void Update()
        {
            MoveForward();
        }

        public void InitBullet(int _damage, Vector3 _direction, Vector3 _position)
        {
            damage = _damage;
            direction = _direction;
            transform.position = _position;
        }

        private void MoveForward()
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = currentPosition + direction * speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}