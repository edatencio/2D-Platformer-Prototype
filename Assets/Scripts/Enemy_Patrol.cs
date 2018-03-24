using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    public float MoveSpeed;
    public bool MoveRight;
    private Rigidbody2D rBody;

    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask IsWall;
    private bool HittingWall;

    private bool NotAtEdge;
    public Transform EdgeCheck;

    void Start () 
	{
	   rBody = gameObject.GetComponent<Rigidbody2D>();

	}//Start


    void Update () 
    {
	   //Evitar que el personaje gire
	   gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

	   HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, IsWall);
	   NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, IsWall);

	   if (HittingWall || !NotAtEdge) { MoveRight = !MoveRight; }
	   
	   if (MoveRight) 
	   { 
		  rBody.velocity = new Vector2(MoveSpeed, rBody.velocity.y);
		  gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

	   } else 
	   {
		  rBody.velocity = new Vector2(-MoveSpeed, rBody.velocity.y);
		  gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
	   
	   }//if else

    }//Update
	
}//public class Enemy_Patrol
