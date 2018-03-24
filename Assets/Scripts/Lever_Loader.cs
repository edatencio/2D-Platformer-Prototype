using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever_Loader : MonoBehaviour
{
    private bool PlayerInTheZone;
    public string SceneToLoad;
    public bool UnlockALevel;
    public string LevelToUnlock;

    void Start ()
    {
	   PlayerInTheZone = false;

    }//Start


    void Update ()
    {
	   if (Input.GetButtonDown("Jump") && PlayerInTheZone)
	   {
		  if (UnlockALevel == true)
		  {
			 PlayerPrefs.SetInt(LevelToUnlock, 1);

		  }//if

		  SceneManager.LoadScene(SceneToLoad);

	   }//if

    }//Update


    void OnTriggerEnter2D (Collider2D col)
    {
	   if (col.name == "Player") { PlayerInTheZone = true; }

    }//void OnTriggerEnter


    void OnTriggerExit2D (Collider2D col)
    {
	   if (col.name == "Player") { PlayerInTheZone = false; }

    }//void OnTriggerEnter

}//public class Lever_Loader
