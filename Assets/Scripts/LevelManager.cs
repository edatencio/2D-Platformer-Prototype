using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
     public float RespawnDelay;
     public GameObject CheckPoint;
     private PlayerController Player;

     public GameObject DeathParticle;
     public GameObject RespawnParticle;
     public int PointPenaltyOnDeath;

     public Health_Manager HealthManager;

     private Lives_Manager LivesManager;

     void Start()
     {
          Player = FindObjectOfType<PlayerController>();
          HealthManager = FindObjectOfType<Health_Manager>();
          LivesManager = FindObjectOfType<Lives_Manager>();

     }//void Start

     //Iniciar la Corutina
     public void RespawnPlayer() { StartCoroutine("RespawnPlayerCo"); }

     public IEnumerator RespawnPlayerCo()
     {
          ScoreManager.AddPoints(-PointPenaltyOnDeath);
          Instantiate(DeathParticle, Player.transform.position, Player.transform.rotation);
          Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
          Player.GetComponent<BoxCollider2D>().enabled = false;
          Player.GetComponent<Renderer>().enabled = false;
          yield return new WaitForSeconds(RespawnDelay);

          if (LivesManager.LivesCounter > 0)
          {
               Health_Manager.FullHealth();
               HealthManager.IsDead = false;
               Player.KnockBackTimer = 0;
               Player.transform.position = CheckPoint.transform.position;
               Instantiate(RespawnParticle, CheckPoint.transform.position, CheckPoint.transform.rotation);
               Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
               Player.GetComponent<BoxCollider2D>().enabled = true;
               Player.GetComponent<Renderer>().enabled = true;
               HealthManager.PauseMenu.gameObject.SetActive(true);
          }
          else if (LivesManager.LivesCounter == 0)
          {
               HealthManager.IsDead = false;
               SceneManager.LoadScene("Game_Over");

          }//if

     }//public void RespawnPlayer

}//public class LevelManager
