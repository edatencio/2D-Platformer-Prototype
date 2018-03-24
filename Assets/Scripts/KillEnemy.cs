using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour 
{
    public LevelManager levelManager;

    void Start ()
    {
	   levelManager = FindObjectOfType<LevelManager>();

    }//void Start

    void OnTriggerEnter2D(Collider2D col)
    {
	   if (col.name == "Enemy")
	   {
		  col.GetComponent<Enemy_Health_Manager>().GiveDamage(101);

	   }//if

    }//void OnTriggerEnter2D

}//public class KillEnemy
