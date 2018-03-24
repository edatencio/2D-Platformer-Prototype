using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Thank_You_For_Playing_Screen : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public string MainMenu;

     public GameObject scoreText;
     private Text score;
     public GameObject highScoreText;
     private Text highScore;


     void Start()
     {
          score = scoreText.GetComponent<Text>();
          highScore = highScoreText.GetComponent<Text>();

          score.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();

          if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
          {
               PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
               highScore.text = "New HighScore!: " + PlayerPrefs.GetInt("HighScore").ToString();

          }//if
          else
               highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();

     }//void Start


     public void GoToMainMenu()
     {
          SceneManager.LoadScene(MainMenu);

     }//void


}//public class Thank_You_For_Playing_Screen