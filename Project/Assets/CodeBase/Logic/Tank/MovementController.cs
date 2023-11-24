using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class MovementController : MonoBehaviour
    {
        private float minX = -37;
        private float maxX = 37;
        private float minY = -24f;
        private float maxY = 24f;

        void Update()
        {
            Vector3 position = transform.position;
            float clampedX = Mathf.Clamp(position.x, minX, maxX);
            float clampedY = Mathf.Clamp(position.y, minY, maxY);

            position = new Vector3(clampedX, clampedY, position.z);
            transform.position = position;
        }
    }
}