﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss_Wall : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
	
	
	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
        
    
    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
        if (!FindObjectOfType<Boss_Health_Manager>())
	   {
		  Destroy(gameObject);

	   }//if
    
    }//void Update
	
    
}//public class Boss_Wall