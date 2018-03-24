using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hurt_On_Contact : MonoBehaviour
{
    public int DamageToGive;
    public float BounceOnEnemy;
    private Rigidbody2D rBody;


    void Start ()
    {
	   rBody = transform.parent.GetComponent<Rigidbody2D>();

    }//Start


    void OnTriggerEnter2D (Collider2D col)
    {
	   if (col.tag == "Enemy")
	   {
		  col.GetComponent<Enemy_Health_Manager>().GiveDamage(DamageToGive);
		  rBody.velocity = new Vector2(rBody.velocity.x, BounceOnEnemy);

	   }//if

    }//void OnTriggerEnter2D
    
}//public class Enemy_Hurt_On_Contact
