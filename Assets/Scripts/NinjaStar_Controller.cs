using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar_Controller : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rBody;
    private PlayerController Player;
    public GameObject DeathParticle;
    public GameObject SparkParticle;
    public int PointsToAdd;
    public float RotationSpeed;
    public int DamagePoints;

    public bool HurtEnemy;


    void Start()
    {
	   rBody = gameObject.GetComponent<Rigidbody2D>();
	   Player = FindObjectOfType<PlayerController>();

	   if (Player.transform.position.x > transform.position.x && HurtEnemy == true) { Speed = -Speed; }
	   if (Player.transform.position.x < transform.position.x && HurtEnemy == false) { Speed = -Speed; }

    }//void Start
    
    
    void Update ()
    {
	   rBody.velocity = new Vector2(Speed, rBody.velocity.y);
	   rBody.angularVelocity = RotationSpeed;
    
    }//void Update


    void OnTriggerEnter2D(Collider2D col)
    {

	   Instantiate(SparkParticle, gameObject.transform.position, gameObject.transform.rotation);
	   Destroy(gameObject);

	   if (col.tag == "Enemy" && HurtEnemy == true)
	   {
		  col.GetComponent<Enemy_Health_Manager>().GiveDamage(DamagePoints);

	   }//if


	   if (col.tag == "Boss" && HurtEnemy == true)
	   {
		  col.GetComponent<Boss_Health_Manager>().GiveDamage(DamagePoints);

	   }//if

    }//void OnTriggerEnter2D


    void OnBecameInvisible ()
    {
	   Destroy(gameObject);

    }//OnBecameInvisible

}//public class NinjaStar_Controller
