using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
   Transform target;

    // Update is called once per frame
    void Update()
    {
        findClosestTarger();
        aimWeapon();
    }

     void findClosestTarger()
    {
       Enemy[] enemies = FindObjectsOfType<Enemy>();
       Transform closestTarget = null;
       float maxDistance = Mathf.Infinity;

       foreach(Enemy enemy in enemies){
           float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

           if(targetDistance < maxDistance){
               closestTarget = enemy.transform;
               maxDistance = targetDistance;
           }

       }
       target = closestTarget;

    }

    void aimWeapon()
    { 
        float targetDistance = Vector3.Distance(transform.position, target.position);


        //weapon.LookAt(target.position);
        weapon.LookAt(target);
        // if(targetDistance>1){
        //     attack(true);
        // }
        // else{
        //     attack(false);
        // }

        if(targetDistance<range){
            attack(true);
        }
        else{
            attack(false);
        }
    }

    void attack(bool isActive){
        // if(isActive){
        //     projectileParticles.emission.enabled.Equals(true);
        // }
        // else{
        //     projectileParticles.emission.enabled.Equals(false);
        // }

        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
