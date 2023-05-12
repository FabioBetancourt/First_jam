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
   private bool isRunning = false;

   private void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      animator = GetComponent<Animator>();
      Physics.gravity *= gravityModifier;
   }
   private void FixedUpdate()
   {
      if (isRunning)
      {
         playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, speed);
      }
   }
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         animator.gameObject.GetComponent<Animator>().Play($"Front Twist Flip");
         isOnGround = false;
      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
         isRunning = true; 
      }

      if (playerRb.velocity.z > 0.1f)
      {
         animator.SetBool("isRunning", true);
      }
      else
      {
         animator.SetBool("isRunning", false);
      }
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
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

      if (collision.gameObject.CompareTag("Obstacle"))
      {
         animator.Play("Stumble Backwards");
         isRunning = false;
         playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
      }
   }
}

