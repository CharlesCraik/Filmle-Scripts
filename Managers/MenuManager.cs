using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    AudioListener audioListen;

    void Start(){
        audioListen = Camera.main.GetComponent<AudioListener>();
        if(PlayerPrefs.GetString("Mute Sound") == "True"){
            audioListen.enabled = false;
        }
        else{
            audioListen.enabled = true;
        }
    }

    public int GetDateSeed(){
        var dateToday = System.DateTime.UtcNow;
        var endOfYear = new System.DateTime(dateToday.Year + 000, 08, 07);
        var diff = endOfYear - dateToday;
        return (int)diff.TotalDays;
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
    
    public void PlayGame(){
        if(PlayerPrefs.GetInt("Word Of The Day") == GetDateSeed()){
           if(PlayerPrefs.GetInt("Result") == 1){
               SceneManager.LoadScene("PlayerWins");
           }
           else if(PlayerPrefs.GetInt("Result") == 2){
               SceneManager.LoadScene("PlayerLoses");
           }
        }
        else{
            PlayerPrefs.DeleteKey("Result");
            SceneManager.LoadScene("Play");  
        }
    }

    public void Community(){
        Debug.Log("Load Community Scene");
    }

    public void Settings(){
        SceneManager.LoadScene("Settings");
    }

    public void UserProfile(){
        SceneManager.LoadScene("Statistics");
    }

    public void HelpUser(){
        SceneManager.LoadScene("Help");
    }

    public void OpenWebsite(){
        Application.OpenURL("https://charlescraik.co/");
    }

    public void QuitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
