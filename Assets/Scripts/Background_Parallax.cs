using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Background_Parallax : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public Transform[] Backgrounds;
    private float[] ParallaxScales;
    public float Smoothing;

    private Transform Cam;
    private Vector3 PreviousCameraPosition;
	
	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   Cam = Camera.main.transform;
	   PreviousCameraPosition = Cam.position;
	   ParallaxScales = new float[Backgrounds.Length];

	   for (int i = 0; i < Backgrounds.Length; i++)
	   {
		  ParallaxScales[i] = Backgrounds[i].position.z * -1;

	   }//for

    }//void Start
    
    
	/*************************************************************************************************
    *** LateUpdate
    *************************************************************************************************/
    void LateUpdate ()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
	   {
		  float Parallax = (PreviousCameraPosition.x - Cam.position.x) *ParallaxScales[i];
		  float BackgroundTargetPosX = Backgrounds[i].position.x + Parallax;
		  Vector3 BackgroundTargetPos = new Vector3(BackgroundTargetPosX, Backgrounds[i].position.y, Backgrounds[i].position.z);

		  Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, BackgroundTargetPos, Smoothing * Time.deltaTime);

	   }//for

	   PreviousCameraPosition = Cam.position;
    
    }//void LateUpdate
	
    
}//public class Background_Parallax