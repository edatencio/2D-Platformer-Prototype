using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Game_Over_Screen : MonoBehaviour
{
     public string SceneToLoadNext;
     public float Delay;

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


     void Update()
     {
          StartCoroutine(WaitASecCo(Delay));

     }//void Update


     private IEnumerator WaitASecCo(float HowLong)
     {
          yield return new WaitForSeconds(HowLong);
          SceneManager.LoadScene(SceneToLoadNext);

     }//WaitASec


}//public class Game_Over_Screen
