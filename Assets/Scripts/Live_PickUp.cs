using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live_PickUp : MonoBehaviour
{
    private Lives_Manager LiveManager;
    public float DestroyDelay;
    private bool Taken;

    void Start ()
    {
	   LiveManager = FindObjectOfType<Lives_Manager>();
    
    }//void Start


    void OnTriggerEnter2D(Collider2D col)
    {
	   if (col.name == "Player" && Taken == false)
	   {
		  LiveManager.GiveLives(1);
		  gameObject.GetComponent<SpriteRenderer>().enabled = false;
		  gameObject.GetComponent<AudioSource>().Play();
		  StartCoroutine(Co_WaitASec(DestroyDelay));
		  Taken = true;

	   }//if

    }//void OnTriggerEnter2D


    private IEnumerator Co_WaitASec (float HowLong)
    {
	   yield return new WaitForSeconds(HowLong);
	   Destroy(gameObject);

    }//WaitASec

}//public class Live_PickUp
