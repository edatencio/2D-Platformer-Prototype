using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_Shoot : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public float PlayerRange;
    public GameObject EnemyStar;
    private PlayerController Player;
    public Transform ShootPoint;

    public float DelayBetweenShots;
    private float ShotCounter;
	
	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   Player = FindObjectOfType<PlayerController>();
	   ShotCounter = DelayBetweenShots;
    
    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   Debug.DrawLine(new Vector3(transform.position.x - PlayerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + PlayerRange, transform.position.y, transform.position.z));
	   ShotCounter -= Time.deltaTime;

	   if (transform.localScale.x > 0 && Player.transform.position.x > transform.position.x && Player.transform.position.x < transform.position.x + PlayerRange && ShotCounter < 0)
	   {
		  Instantiate(EnemyStar, ShootPoint.position, ShootPoint.rotation);
		  ShotCounter = DelayBetweenShots;

	   }//if

	   
	   if (transform.localScale.x < 0 && Player.transform.position.x < transform.position.x && Player.transform.position.x > transform.position.x - PlayerRange && ShotCounter < 0)
	   {
		  Instantiate(EnemyStar, ShootPoint.position, ShootPoint.rotation);
		  ShotCounter = DelayBetweenShots;

	   }//if
	   

    }//void Update
	
    
}//public class Enemy_Shoot