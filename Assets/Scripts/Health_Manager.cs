using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Manager : MonoBehaviour
{
     public static int PlayerHealth;
     public int Health;
     public int MaxPlayerHealth;
     private LevelManager levelManager;
     public bool IsDead;
     public Pause_Menu PauseMenu;

     public Slider HealthBar;

     private Lives_Manager LivesManager;

     void Start()
     {
          HealthBar = GetComponent<Slider>();

          levelManager = FindObjectOfType<LevelManager>();
          LivesManager = FindObjectOfType<Lives_Manager>();
          PauseMenu = FindObjectOfType<Pause_Menu>();

          PlayerHealth = PlayerPrefs.GetInt("Health");

          IsDead = false;

     }//void Start


     void Update()
     {
          if (PlayerHealth <= 0 && !IsDead)
          {
               PauseMenu.gameObject.SetActive(false);
               PlayerHealth = 0;
               levelManager.RespawnPlayer();
               LivesManager.TakeLives(1);
               IsDead = true;

          }//if

          //text.text = "HP: " + PlayerHealth;
          HealthBar.value = PlayerHealth;

     }//void Update


     public static void HurtPlayer(int HowMuch)
     {
          PlayerHealth -= HowMuch;
          PlayerPrefs.SetInt("Health", PlayerHealth);

     }//public static void HurtPlayer


     public static void FullHealth()
     {
          PlayerHealth = PlayerPrefs.GetInt("MaxHealth");
          PlayerPrefs.SetInt("Health", PlayerHealth);

     }//public void FullHealth


}//public class Health_Manager
