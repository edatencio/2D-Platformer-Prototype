using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Patrol : MonoBehaviour
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

    private float BossSize;

    void Start () 
	{
	   rBody = gameObject.GetComponent<Rigidbody2D>();
	   BossSize = Mathf.Abs(transform.localScale.x);

	}//Start


	void FixedUpdate ()
	{
	   HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, IsWall);
	   NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, IsWall);

    }//FixedUpdate

    void Update () 
    {
	   //Evitar que el personaje gire
	   gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

	   if (HittingWall || !NotAtEdge) { MoveRight = !MoveRight; }
	   
	   if (MoveRight) 
	   { 
		  rBody.velocity = new Vector2(MoveSpeed, rBody.velocity.y);
		  gameObject.transform.localScale = new Vector3(BossSize, BossSize, 1f);

	   } else 
	   {
		  rBody.velocity = new Vector2(-MoveSpeed, rBody.velocity.y);
		  gameObject.transform.localScale = new Vector3(-BossSize, BossSize, 1f);
	   
	   }//if else

    }//Update

}//public class Boss_Patrol
