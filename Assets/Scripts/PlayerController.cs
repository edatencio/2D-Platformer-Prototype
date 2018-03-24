using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float MoveSpeed;
     public float JumpHeight;
     private bool DoubleJumped;
     private float MoveVelocity;

     public Transform GroundCheck;
     public float GroundCheckRadius;
     public LayerMask IsGround;
     private bool Grounded;

     private Rigidbody2D rBody2D;

     private Animator anim;

     public Transform FirePoint;
     public GameObject NinjaStar;

     public float KnockBack;
     public float KnockBackLength;
     public float KnockBackTimer;
     public bool KnockBackFromRight;


     /*************************************************************************************************
     *** Ladder variables
     *************************************************************************************************/
     public bool OnLadder;
     public float ClimbSpeed;
     private float ClimbVelocity;
     private float GravityStore;


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start()
     {
          rBody2D = gameObject.GetComponent<Rigidbody2D>();
          anim = GetComponent<Animator>();
          OnLadder = false;

          GravityStore = rBody2D.gravityScale;

     }//void Start


     /*************************************************************************************************
     *** Fixed Update
     *************************************************************************************************/
     void FixedUpdate()
     {
          Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, IsGround);

     }//FixedUpdate


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update()
     {
          //Evitar que el personaje gire
          gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

          if (Grounded)
               DoubleJumped = false;

          //Salto
          if (Input.GetButtonDown("Jump") && (Grounded || (!DoubleJumped && !Grounded)))
          {
               Move(rBody2D.velocity.x, JumpHeight);
               DoubleJumped = true;

          }//if KeyDown Space

          /*MoveVelocity = 0f;

          //Mover derecha
          if (Input.GetKey(KeyCode.D))
          {
              MoveVelocity = MoveSpeed;

          }//if KeyDown Space

          //Mover izquierda
          if (Input.GetKey(KeyCode.A))
          {
              MoveVelocity = -MoveSpeed;

          }//if KeyDown Space
          */

          MoveVelocity = MoveSpeed * Input.GetAxisRaw("Horizontal");

          Move(MoveVelocity, rBody2D.velocity.y);

          anim.SetFloat("Speed", Mathf.Abs(rBody2D.velocity.x));
          anim.SetBool("Grounded", Grounded);

          //if going right
          if (rBody2D.velocity.x > 0)
               gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
          //else if going left
          else if (rBody2D.velocity.x < 0)
               gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);

          if (Input.GetButtonDown("Fire1"))
               Instantiate(NinjaStar, FirePoint.position, FirePoint.rotation);

          if (anim.GetBool("Sword"))
               anim.SetBool("Sword", false);

          if (Input.GetButtonDown("Fire2"))
               anim.SetBool("Sword", true);


          //*** Ladder code
          if (OnLadder)
          {
               rBody2D.gravityScale = 0f;
               ClimbVelocity = ClimbSpeed * Input.GetAxisRaw("Vertical");
               Move(rBody2D.velocity.x, ClimbVelocity);

          }
          else if (!OnLadder)
          {
               rBody2D.gravityScale = GravityStore;

          }//else if 

     }//Update


     /*************************************************************************************************
     *** Move - Funcion para moverse
     *************************************************************************************************/
     public void Move(float x, float y)
     {
          //Si no existe knockback, el personaje se mueve normalmente
          if (KnockBackTimer <= 0) { rBody2D.velocity = new Vector2(x, y); }
          else
          {
               //Si el knockback proviene de la derecha, se desplaza el personaje a la izquierda
               if (KnockBackFromRight) { rBody2D.velocity = new Vector2(-KnockBack, KnockBack); }

               //Y vice versa
               if (!KnockBackFromRight) { rBody2D.velocity = new Vector2(KnockBack, KnockBack); }

               //Se reduce el contador
               KnockBackTimer -= Time.deltaTime;

          }//else

     }//public void Move


     /*************************************************************************************************
     *** OnCollisionEnter2D
     *************************************************************************************************/
     void OnCollisionEnter2D(Collision2D col)
     {
          if (col.transform.tag == "Moving_Platform")
          {
               transform.parent = col.transform;

          }//if

     }//OnCollisionEnter2D


     /*************************************************************************************************
     *** OnCollisionExit2D
     *************************************************************************************************/
     void OnCollisionExit2D(Collision2D col)
     {
          if (col.transform.tag == "Moving_Platform")
          {
               transform.parent = null;

          }//if

     }//OnCollisionExit2D

}//public class PlayerController
