using CodeBase.Static_Data;
using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class MovementController : MonoBehaviour
    {
        private readonly int _minX = PlaneSize.PlaneWidth / 2 * -1;
        private readonly int _maxX = PlaneSize.PlaneWidth / 2;
        private readonly int _minY = PlaneSize.PlaneLength / 2 * -1;
        private readonly int _maxY = PlaneSize.PlaneLength / 2;

        void Update()
        {
            Vector3 position = transform.position;
            float clampedX = Mathf.Clamp(position.x, _minX, _maxX);
            float clampedY = Mathf.Clamp(position.y, _minY, _maxY);

            position = new Vector3(clampedX, clampedY, position.z);
            transform.position = position;
        }
    }
}