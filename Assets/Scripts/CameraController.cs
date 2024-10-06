﻿
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {

        public float sensitivity = 2.0f;
        public float maxYAngle = 80.0f;

        private float rotationX = 0.0f;

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(Vector3.up * mouseX * sensitivity);

            rotationX -= mouseY * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
            transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);

        }
    }
}