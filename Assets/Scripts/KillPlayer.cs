using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour 
{
    public LevelManager levelManager;

    void Start ()
    {
	   levelManager = FindObjectOfType<LevelManager>();

    }//void Start

    void OnTriggerEnter2D(Collider2D col)
    {
	   if (col.name == "Player")
	   {
		  levelManager.RespawnPlayer();

	   }//if

    }//void OnTriggerEnter2D

}//public class KillPlayer
