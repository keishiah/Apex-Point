using UnityEngine;

namespace CodeBase.Logic
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public int damage;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float speed = 10f;
        private readonly int color = Shader.PropertyToID("_Color");
        private void Update()
        {
            MoveForward();
            DeactivateBullet();
        }

        public void InitBullet(int damage, Vector3 direction, Vector3 position, Color color)
        {
            this.damage = damage;
            this.direction = direction;
            transform.position = position;
            GetComponent<MeshRenderer>().material.SetColor(this.color, color);
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