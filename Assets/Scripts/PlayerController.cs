using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
   private Rigidbody playerRb;
   public float speed;
   public float jumpForce = 10f;
   public float gravityModifier;
   public bool isOnGround = true;


   private void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      Physics.gravity *= gravityModifier;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         isOnGround = false;
      }
      if (Input.GetKey(KeyCode.W))
      {
         transform.Translate(Vector3.forward * (speed * Time.deltaTime));
      }
      if (Input.GetKey(KeyCode.S))
      {
         transform.Translate(Vector3.back * (speed * Time.deltaTime));
      }
      
   }

   private void OnCollisionEnter(Collision collision)
   {
      isOnGround = true;
   }
}

