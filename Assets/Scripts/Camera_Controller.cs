using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public PlayerController Player;
    public bool IsFollowing;

    public float xOffset;
    public float yOffset;

    void Start ()
    {
       Player = FindObjectOfType<PlayerController>();
       IsFollowing = true;
    
    }//Start
	
	
    void Update ()
    {
	   if (IsFollowing) { gameObject.transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, gameObject.transform.position.z); }
	
    }//Update

}//public class Camera_Controller
