using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Time_Manager : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public float StartingTime;
    private float CurrentTime;
    private Text TheText;
	
	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   TheText = GetComponent<Text>();
	   CurrentTime = StartingTime;
    
    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   CurrentTime -= Time.deltaTime;
	   
	   if (CurrentTime <= 0)
	   {
		  CurrentTime = StartingTime;
		  Health_Manager.HurtPlayer(101);
		  GetComponent<AudioSource>().Play();

	   }//if

	   TheText.text = "Time: " + Mathf.Round(CurrentTime);
    
    }//void Update
	
    
}//public class Time_Manager