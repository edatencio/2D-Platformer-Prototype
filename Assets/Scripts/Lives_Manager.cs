using UnityEngine;
using UnityEngine.UI;


public class Lives_Manager : MonoBehaviour
{
     public int LivesCounter;
     private Text TheText;

     void Start()
     {
          TheText = gameObject.GetComponent<Text>();
          LivesCounter = PlayerPrefs.GetInt("Lives");

     }//void Start


     void Update()
     {
          TheText.text = " x " + LivesCounter;

     }//void Update


     public void GiveLives(int HowMany)
     {
          LivesCounter += HowMany;
          if (LivesCounter > 99) { LivesCounter = 99; }

          PlayerPrefs.SetInt("Lives", LivesCounter);

     }//GiveLives


     public void TakeLives(int HowMany)
     {
          LivesCounter -= HowMany;
          if (LivesCounter < 0) { LivesCounter = 0; }

          PlayerPrefs.SetInt("Lives", LivesCounter);

     }//TakeLives

}//public class Lives_Manager
