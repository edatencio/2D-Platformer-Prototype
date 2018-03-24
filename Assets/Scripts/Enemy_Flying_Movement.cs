using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_Flying_Movement : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    private PlayerController Player;
    public float MoveSpeed;
    public float PlayerDetectRange;

    public LayerMask PlayerLayer;
    private bool PlayerInRange;

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   Player = FindObjectOfType<PlayerController>();
	   PlayerInRange = false;
    
    }//void Start


    /*************************************************************************************************
    *** FixedUpdate
    *************************************************************************************************/
    void FixedUpdate ()
    {
	   PlayerInRange = Physics2D.OverlapCircle(transform.position, PlayerDetectRange, PlayerLayer);

    }//void FixedUpdate


    /*************************************************************************************************
   *** Update
   *************************************************************************************************/
    void Update ()
    {
	   PlayerInRange = Physics2D.OverlapCircle(transform.position, PlayerDetectRange, PlayerLayer);
	   
	   if (PlayerInRange == true)
	   {
		  transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);

	   }//if

    }//void Update


    void OnDrawGizmosSelected ()
    {
	   Gizmos.DrawSphere(transform.position, PlayerDetectRange);

    }//OnDrawGizmosSelected
    
}//public class Enemy_Flying_Movement