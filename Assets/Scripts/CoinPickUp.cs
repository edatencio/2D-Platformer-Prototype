using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int PointsToAdd;
    public float DestroyDelay;
    private bool Taken;

    void Start () { Taken = false; }

    void OnTriggerEnter2D (Collider2D col)
    {
	   if (col.name == "Player" && Taken == false)
	   {
		  gameObject.GetComponent<SpriteRenderer>().enabled = false;
		  gameObject.GetComponent<AudioSource>().Play();
		  ScoreManager.AddPoints(PointsToAdd);
		  PlsWait(DestroyDelay);
		  Taken = true;

	   }//if

    }//void OnTriggerEnter2D

    
    private IEnumerator PlsWait(float HowLong)
    {
	   yield return new WaitForSeconds(HowLong);
	   Destroy(gameObject);

    }//private IEnumerator PlsWait

}//public class CoinPickUp
