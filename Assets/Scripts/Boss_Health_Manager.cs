using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health_Manager : MonoBehaviour
{
    public int MaxEnemyHealth;    
    private int EnemyHealth;
    public GameObject DeathParticle;
    public int PointsOnDeath;

    public GameObject BossPrefab;
    public float MinSize;

    public int ClonesHealthDivideFactor;
    public float ClonesShrinkFactor;

    void Start ()
    {
	   EnemyHealth = MaxEnemyHealth;

    }//Start

    void Update ()
    {
        if (EnemyHealth <= 0)
	   {
		  Instantiate(DeathParticle, gameObject.transform.position, gameObject.transform.rotation);
		  ScoreManager.AddPoints(PointsOnDeath);

		  if (transform.localScale.y > MinSize)
		  {
			 GameObject clone1 = Instantiate(BossPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
			 GameObject clone2 = Instantiate(BossPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

			 clone1.transform.localScale = new Vector3(transform.localScale.x * ClonesShrinkFactor, transform.localScale.y * ClonesShrinkFactor, transform.position.z);
			 clone1.GetComponent<Boss_Health_Manager>().EnemyHealth = MaxEnemyHealth / ClonesHealthDivideFactor;

			 clone2.transform.localScale = new Vector3(transform.localScale.x * ClonesShrinkFactor, transform.localScale.y * ClonesShrinkFactor, transform.position.z);
			 clone2.GetComponent<Boss_Health_Manager>().EnemyHealth = MaxEnemyHealth / ClonesHealthDivideFactor;
			 clone2.GetComponent<Boss_Patrol>().MoveRight = !clone2.GetComponent<Boss_Patrol>().MoveRight;

		  }//if

		  Destroy(gameObject);

	   }//if




    
    }//void Update


    public void GiveDamage (int HowMuch)
    {
	   gameObject.GetComponent<AudioSource>().Play();
	   EnemyHealth -= HowMuch;

    }//public void GiveDamage

}//public class Boss_Health_Manager
