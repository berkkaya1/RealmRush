using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance{get{return currentBalance;}}

    void Awake(){
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
        
    }

    public void withdraw(int amount){
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance < 0){
            //Lose the game;
            //Debug.Log("Game Over");
            reloadScene();
        }
    }

    void reloadScene(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDisplay(){
        displayBalance.text = "Gold:" + currentBalance;
    }

    //Benim yazdıgım- o ayri method olusturdu.
    //  void Update() {
    //     displayBalance.text = "Gold: "+currentBalance.ToString();
    // }
}
