using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
     public static int Score;
     Text TheText;

     void Start()
     {
          TheText = GetComponent<Text>();
          Score = PlayerPrefs.GetInt("Score");

     }//Start


     //Evita que el puntaje baje de cero y actualiza el texto en pantalla
     void Update()
     {
          if (Score < 0)
          {
               Score = 0;
               PlayerPrefs.SetInt("Score", Score);

          }//if

          TheText.text = "Score: " + Score;

     }//Update


     //Funcion para añadir puntos
     public static void AddPoints(int HowMany)
     {
          Score += HowMany;
          PlayerPrefs.SetInt("Score", Score);

     }//AddPoints


     //Funcion para reiniciar el puntaje
     public static void ScoreReset()
     {
          Score = 0;
          PlayerPrefs.SetInt("Score", Score);

     }//ScoreReset

}//public class ScoreManager
