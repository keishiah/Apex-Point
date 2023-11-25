using UnityEngine;

namespace CodeBase.Logic.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public int damage;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float speed = 10f;
        private readonly int _color = Shader.PropertyToID("_Color");
        private void Update()
        {
            MoveForward();
            DeactivateBullet();
        }

        public void InitBullet(int initDamage, Vector3 initDirection, Vector3 position, Color color)
        {
            damage = initDamage;
            direction = initDirection;
            transform.position = position;
            GetComponent<MeshRenderer>().material.SetColor(_color, color);
        }

        private void MoveForward()
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = currentPosition + direction * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        private void DeactivateBullet()
        {
            if (transform.position.x is > 50 or < -50 || transform.position.y is > 50 or < -50)
                gameObject.SetActive(false);
        }
    }
}