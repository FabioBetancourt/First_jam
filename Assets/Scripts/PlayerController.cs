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
   private Animator animator;

   private void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      animator = GetComponent<Animator>();
      Physics.gravity *= gravityModifier;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         animator.gameObject.GetComponent<Animator>().Play($"Front Twist Flip");
         isOnGround = false;
      }
      
      if (Input.GetKey(KeyCode.W))
      {
         transform.Translate(Vector3.forward * (speed * Time.deltaTime));
         animator.SetBool("isRunning", true); // Activa la animación de correr
         Debug.Log(animator.GetBool("isRunning"));
      }
      else if (Input.GetKeyUp(KeyCode.W))
      {
         animator.SetBool("isRunning", false); // Detiene la animación de correr
      }
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      isOnGround = true;
      if (Input.GetKey(KeyCode.W))
      {
         animator.SetBool("isRunning", true); // Continúa la animación de correr si "W" todavía está siendo presionada
      }
      else
      {
         animator.SetBool("isRunning", false); // Cambia a la animación por defecto si ninguna tecla está siendo presionada
      }
   }
}

