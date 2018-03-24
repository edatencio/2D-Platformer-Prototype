using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public string gameSceneName;
     public string levelSelectName;
     public GameObject aboutPanel;
     public GameObject exitButtonEnabled;
     public GameObject exitButtonDisabled;


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start()
     {
          PlayerPrefs.SetInt("MaxHealth", 5);
          PlayerPrefs.SetInt("Lives", 5);
          PlayerPrefs.SetInt("Score", 0);
          PlayerPrefs.SetInt("HighScore", 430);

          Health_Manager.FullHealth();
          ScoreManager.ScoreReset();

          PlayerPrefs.SetInt("Level Select Position", 0);
          PlayerPrefs.SetInt("Level 1", 1);
          PlayerPrefs.SetInt("Level 2", 0);
          PlayerPrefs.SetInt("Level 3", 0);
          PlayerPrefs.SetInt("Level 4", 0);

          Time.timeScale = 1f;

          #if UNITY_WEBGL
               exitButtonEnabled.SetActive(false);
               exitButtonDisabled.SetActive(true);
          #else
               exitButtonEnabled.SetActive(true);
               exitButtonDisabled.SetActive(false);
          #endif

     }//void Start


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update ()
     {
          if (Input.GetButtonDown("Submit"))
               Start_Game();

          if (Input.GetButtonDown("Cancel"))
               Exit_Game();
          	
     }//void Update

     
     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
     public void Start_Game()
     {
          SceneManager.LoadScene(gameSceneName);

     }//public void Start_Game


     public void Level_Select()
     {
          PlayerPrefs.SetInt("Level 2", 1);
          PlayerPrefs.SetInt("Level 3", 1);
          PlayerPrefs.SetInt("Level 4", 1);
          SceneManager.LoadScene(levelSelectName);

     }//public void Level_Select


     public void Exit_Game()
     {
          Application.Quit();
          
     }//public void Exit_Game
     

     public void About_Panel_Open()
     {
          aboutPanel.SetActive(true);

     }//public void About_Panel_Open


     public void About_Panel_Close()
     {
          aboutPanel.SetActive(false);

     }//public void About_Panel_Close


}//public class UI_Menu_Buttons
