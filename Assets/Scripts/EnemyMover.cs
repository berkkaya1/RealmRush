using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
  [SerializeField] List<Waypoint> path = new List<Waypoint>();
  [SerializeField] [Range(0f, 5f)] float speed = 1f;
  Enemy enemy;

  void OnEnable() {
      findPath();
      ReturnToStart();
      StartCoroutine(followPath());

  }

 void Start(){
     enemy = GetComponent<Enemy>();
 }
  void findPath(){

      path.Clear();

      //tek tek yollara tag vermek yerine parent objesine verip onu findgameobjectwithtag ile buldu
      GameObject parent = GameObject.FindGameObjectWithTag("Path");

      foreach (Transform child in parent.transform)
      {   Waypoint waypoint = child.GetComponent<Waypoint>();

         if(waypoint != null){
           path.Add(waypoint);
         }
          
      }
  }

 //enemy spawn olunca uzakta bir yerde dogmasın diye ilk pathdan itibaren
 //olusturuluyor.
  void ReturnToStart(){
      transform.position = path[0].transform.position;
  }


  void finishPath(){
      enemy.stealGold();
      gameObject.SetActive(false);
  }

  /* Invoke yerine Coroutines kullanıyoruz 
  IEnumerator yazıp returndan önce yield ekliyoruz
  sonuna bekleme yaptırmak icin new waitforseconds(time);
  ve cagirirken startcoroutine diyoruz.
  */ 
  IEnumerator followPath(){

      foreach(Waypoint waypoint in path){
          //transform.position = waypoint.transform.position;
          //yield return new WaitForSeconds(waitTime);
          
          Vector3 startPosition = transform.position;
          Vector3 endPosition = waypoint.transform.position;
          float travelPercent = 0f;

          transform.LookAt(endPosition);

          while(travelPercent < 1f){
           travelPercent += Time.deltaTime * speed;
           transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
           yield return new WaitForEndOfFrame();
          }
         
      }
      
      finishPath();
      
  }
   
   
  
}
