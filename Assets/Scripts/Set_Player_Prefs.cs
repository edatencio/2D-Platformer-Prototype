using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Set_Player_Prefs : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public bool ActivateScript;
    public string[] PrefKey;
    public string[] PrefType;
    public string[] PrefValue;


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start()
    {

	   if (PrefKey.Length != PrefType.Length || PrefType.Length != PrefValue.Length)
	   {
		  Debug.Log("Set_Player_Prefs Script - The arrays sizes dont match.");
		  ActivateScript = false;

	   }//if

	   if (ActivateScript == true)
	   {
		  Debug.Log("Set_Player_Prefs Script Attached To: " + gameObject.name + " - ACTIVE");

		  for (int i = 0; i < PrefKey.Length; i++)
		  {
			 if (PrefKey[i] == "" || PrefType[i] == "" || PrefValue[i] == "")
			 {
				Debug.Log("Set_Player_Prefs Script - PlayerPref number " + i + " is NOT correctly set.");

			 } else
			 {
				switch (PrefType[i])
				{
				    case "Int":
					   PlayerPrefs.SetInt(PrefKey[i], int.Parse(PrefValue[i]));
					   break;

				    case "Float":
					   PlayerPrefs.SetFloat(PrefKey[i], float.Parse(PrefValue[i]));
					   break;

				    case "String":
					   PlayerPrefs.SetString(PrefKey[i], PrefValue[i]);
					   break;

				    default:
					   Debug.Log("Set_Player_Prefs Script - PlayerPref number " + i + " TYPE is NOT correctly set.");
					   break;

				}//switch

			 }//else

		  }//for

	   } else
	   {
		  Debug.Log("Set_Player_Prefs Script Attached To: " + gameObject.name + " - INACTIVE");

	   }//else

    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
        
    
    }//void Update
	
    
}//public class Set_Player_Prefs