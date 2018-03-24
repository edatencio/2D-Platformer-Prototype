using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Climb : MonoBehaviour
{
    private PlayerController Player;
    
    
    void Start ()
    {
	   Player = FindObjectOfType<PlayerController>();
    
    }//void Start
    

    void OnTriggerEnter2D (Collider2D col)
    {
	   if (col.name == "Player")
	   {
		  Player.OnLadder = true;

	   }//if

    }//OnTriggerEnter2D


    void OnTriggerExit2D(Collider2D col)
    {
	   if (col.name == "Player")
	   {
		  Player.OnLadder = false;

	   }//if

    }//OnTriggerExit2D

}//public class Ladder_Climb
