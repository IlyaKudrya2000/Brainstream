﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   public float sensitivity = 100.0f;
   public Transform playerBody;
   public Transform hand;
   private float rotationX = 0.0f;
   void Start()
   {
        Cursor.lockState = CursorLockMode.Locked;
   }
   void Update()
   {
       float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
       
       rotationX -= mouseY;
       rotationX = Mathf.Clamp(rotationX, -90f, 90f);
       transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
       playerBody.Rotate(Vector3.up * mouseX);

       hand.localRotation = Quaternion.Euler(rotationX, mouseX, 0);
   }
}