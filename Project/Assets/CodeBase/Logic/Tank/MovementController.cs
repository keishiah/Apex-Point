using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class MovementController : MonoBehaviour
    {
        private const float MinX = -37;
        private const float MaxX = 37;
        private const float MinY = -24f;
        private const float MaxY = 24f;

        void Update()
        {
            Vector3 position = transform.position;
            float clampedX = Mathf.Clamp(position.x, MinX, MaxX);
            float clampedY = Mathf.Clamp(position.y, MinY, MaxY);

            position = new Vector3(clampedX, clampedY, position.z);
            transform.position = position;
        }
    }
}