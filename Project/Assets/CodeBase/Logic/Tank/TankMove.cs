﻿using UnityEngine;

namespace CodeBase.Logic.Tank
{
    public class TankMove : MonoBehaviour
    {
        public float speed = 2.0f;

        private CharacterController _characterController;
        private float _horizontalInput;
        private float _verticalInput;

        private void Start()
        {
            _characterController = GetComponentInParent<CharacterController>();
        }

        private void Update()
        {
            SetMovingDirection();
            Move();
        }

        private void Move()
        {
            _verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = new Vector3(0, _verticalInput, 0);
            if (inputDir.sqrMagnitude > .01f)
                _characterController.Move(speed * transform.forward * _verticalInput * Time.deltaTime);
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
        }
    }
}