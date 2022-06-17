using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{   [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

     //Starttan bile önce çalışıyor.
     void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        //!neden getcomponentinparent yaptı ?
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        //Uygulama çalışmıyorken (edit modundayken)
        if(!Application.isPlaying){
             DisplayCoordinates();
             UpdateObjectName();
        }

        setLabelColor();
        ToggleLabels();
    }

    void ToggleLabels(){
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

     void setLabelColor()
    {
        if(waypoint.IsPlaceable){
           label.color = defaultColor;
        }
        else{
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    { 
       //x ve z ile ugtastigimiz icin 2 boyutlu vektormuzde y aslında z datası oluyor.
       //Grid oranına bölüp daha sade hale getirmek icin snapsettingsten grid oranını cektik.
       coordinates.x = Mathf.RoundToInt(transform.parent.position.x /UnityEditor.EditorSnapSettings.move.x);
       coordinates.y = Mathf.RoundToInt(transform.parent.position.z  /UnityEditor.EditorSnapSettings.move.z);
       label.text =coordinates.x+" "+coordinates.y;
    }


    //transform.parent dememizin sebebi father child iliskisi olmasından dolayı.
     void UpdateObjectName(){
         transform.parent.name = coordinates.ToString();
     }

}
