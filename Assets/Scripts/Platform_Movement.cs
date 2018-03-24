using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Platform_Movement : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public GameObject Platform;
    public float MoveSpeed;
    private Transform CurrentPoint;
    public Transform[] Points;
    public int PointSelection;
	

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   CurrentPoint = Points[PointSelection];
    
    }//void Start
    
    
    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, CurrentPoint.position, Time.deltaTime * MoveSpeed);
	   
	   if (Platform.transform.position == CurrentPoint.position)
	   {
		  PointSelection++;
		  
		  if (PointSelection == Points.Length)
		  {
			 PointSelection = 0;

		  }//if

		  CurrentPoint = Points[PointSelection];

	   }//if

    }//void Update
	
    
}//public class Platform_Movement