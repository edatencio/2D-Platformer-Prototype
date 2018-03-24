using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Select_Manager : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public string[] LevelNames;
     public GameObject[] Locks;
     public bool[] LevelUnLocked;

     public int PositionSelector;
     public float IconOffset;
     public float IconMoveSpeed;
     public bool IsPressed;


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start()
     {
          for (int i = 0; i < LevelNames.Length; i++)
          {
               if (PlayerPrefs.GetInt(LevelNames[i]) != 1)
                    LevelUnLocked[i] = false;
               else
                    LevelUnLocked[i] = true;

               if (LevelUnLocked[i])
               {
                    Locks[i].SetActive(false);

               }//if

          }//for

          PositionSelector = PlayerPrefs.GetInt("Level Select Position");
          transform.position = Locks[PositionSelector].transform.position + new Vector3(0, IconOffset, 0);

     }//void Start


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update()
     {
          if (IsPressed == false)
          {
               if (Input.GetAxis("Horizontal") > 0.25f)
               {
                    PositionSelector++;
                    IsPressed = true;

               }
               else if (Input.GetAxis("Horizontal") < -0.25f)
               {
                    PositionSelector--;
                    IsPressed = true;

               }//else

               if (PositionSelector >= LevelNames.Length)
               {
                    PositionSelector = LevelNames.Length - 1;

               }
               else if (PositionSelector < 0)
               {
                    PositionSelector = 0;

               }//else

          }
          else
          {
               if (Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
               {
                    IsPressed = false;

               }//if

          }// else

          transform.position = Vector3.MoveTowards(transform.position, Locks[PositionSelector].transform.position + new Vector3(0, IconOffset, 0), IconMoveSpeed * Time.deltaTime);

          if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
          {
               if (LevelUnLocked[PositionSelector] == true)
               {
                    PlayerPrefs.SetInt("Level Select Position", PositionSelector);
                    SceneManager.LoadScene(LevelNames[PositionSelector]);

               }//if

          }//if

     }//void Update


}//public class Level_Select_Manager