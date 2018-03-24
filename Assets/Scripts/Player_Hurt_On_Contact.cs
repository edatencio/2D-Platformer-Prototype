using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hurt_On_Contact : MonoBehaviour
{
    public int GiveDamage;

    void OnTriggerEnter2D(Collider2D col)
    {
	   if (col.name == "Player")
	   {
		  Health_Manager.HurtPlayer(GiveDamage);
		  col.GetComponent<AudioSource>().Play();

		  //Knockback
		  var player = col.GetComponent<PlayerController>();
		  player.KnockBackTimer = player.KnockBackLength;

		  if (col.transform.position.x < gameObject.transform.position.x) { player.KnockBackFromRight = true; }
		  else { player.KnockBackFromRight = false; }

	   }//if

    }//void OnTriggerEnter2D

}//public class Player_Hurt_On_Contact
