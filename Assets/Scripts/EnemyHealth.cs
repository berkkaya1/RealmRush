using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptin eklenmesini zorunlu kılıyor.
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adss amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
     int currentHitPoints = 0;   
    
    Enemy enemy; 
    
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start(){
     enemy = GetComponent<Enemy>();
    }

   
       void OnParticleCollision(GameObject other) {
         processHit();
     }

    private void processHit()
    {
        currentHitPoints--;

        if(currentHitPoints<=0){
            //Destroy(gameObject);
            //Yok etmek yerine object pool kullangimiz icin setactive false diyerek gizliyoruz.
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.rewardGold();
           
        }
    }
}
    

