using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class TankMove : MonoBehaviour
    {
        public float speed = 2.0f;

        private CharacterController characterController;
        private float horizontalInput;
        private float verticalInput;

        private void Start()
        {
            characterController = GetComponentInParent<CharacterController>();
        }

        private void Update()
        {
            SetMovingDirection();
            Move();
        }

        private void Move()
        {
            verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = new Vector3(0, verticalInput, 0);
            if (inputDir.sqrMagnitude > .01f)
                characterController.Move(speed * transform.forward * verticalInput * Time.deltaTime);
        }

        private void SetMovingDirection()
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, 100 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -100 * Time.deltaTime);
            }

            transform.Rotate(Vector3.up, horizontalInput * 5f * Time.deltaTime);
            transform.Rotate(Vector3.right, -verticalInput * 5f * Time.deltaTime);
        }
    }
}