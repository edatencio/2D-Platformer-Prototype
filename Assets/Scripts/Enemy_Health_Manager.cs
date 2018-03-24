using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health_Manager : MonoBehaviour
{
    public int EnemyHealth;
    public GameObject DeathParticle;
    public int PointsOnDeath;
    

    void Update ()
    {
        if (EnemyHealth <= 0)
	   {
		  Instantiate(DeathParticle, gameObject.transform.position, gameObject.transform.rotation);
		  ScoreManager.AddPoints(PointsOnDeath);
		  Destroy(gameObject);

	   }//if
    
    }//void Update


    public void GiveDamage (int HowMuch)
    {
	   gameObject.GetComponent<AudioSource>().Play();
	   EnemyHealth -= HowMuch;

    }//public void GiveDamage
    
}//public class Enemy_Health_Manager
