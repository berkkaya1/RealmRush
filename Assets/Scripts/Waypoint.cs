using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    //Get methodu yerine bu tarz kullanım yapıyor
    public bool IsPlaceable{ get{ return isPlaceable;}}
  

     void OnMouseDown() {
        if(isPlaceable){
            //Debug.Log(transform.name);
            //towerPrefab.SetActive(true);

            //Objenin klonunu olusturarak istenilen parametlelerle yerleştiriyor.
            // Instantiate(towerPrefab,transform.position,Quaternion.identity);
            //Aynı yere tower koyamamak için yapılan değişiklik.

            bool isPlaced =  towerPrefab.createTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
           
        }
    }
}
