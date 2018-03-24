using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public LevelManager levelManager;


    void Start()
    {
	   levelManager = FindObjectOfType<LevelManager>();

    }//void Start


    void OnTriggerEnter2D(Collider2D col)
    {
	   if (col.name == "Player")
	   {
		  levelManager.CheckPoint = gameObject;
		  Destroy(gameObject.GetComponent<BoxCollider2D>());

	   }//if

    }//void OnTriggerEnter2D

}//public class CheckPoints
