using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("User Interface")]
    public Toggle showGuessToggle;
    public Toggle muteSoundToggle;

    [Header("Settings")]
    public bool showGuesses = true;
    public bool muteSound = false;

    // Start is called before the first frame update
    void Start(){
        CheckIfNull();

        if(PlayerPrefs.GetString("Mute Sound") == "True"){
            muteSoundToggle.isOn = true;
        }
        else{
            muteSoundToggle.isOn = false;
        }

        if(PlayerPrefs.GetString("Show Guesses") == "True"){
            showGuessToggle.isOn = true;
        }
        else{
            showGuessToggle.isOn = false;
        }
    }

    void CheckIfNull(){
        string soundStr = PlayerPrefs.GetString("Mute Sound");
        if(string.IsNullOrEmpty(soundStr) == true){
            PlayerPrefs.SetString("Mute Sound", muteSound.ToString());
            Debug.Log("Valid answer");
        }
        else{
            Debug.Log("Check Over");
        }

        string guessStr = PlayerPrefs.GetString("Show Guesses");
        if(string.IsNullOrEmpty(guessStr) == true){
            PlayerPrefs.SetString("Show Guesses", showGuesses.ToString());
            Debug.Log("Valid answer");
        }
        else{
            Debug.Log("Check Over");
        }
    }

    // Update is called once per frame
    void Update(){
        showGuesses = showGuessToggle.isOn;
        PlayerPrefs.SetString("Show Guesses", showGuesses.ToString());

        muteSound = muteSoundToggle.isOn;
        PlayerPrefs.SetString("Mute Sound", muteSound.ToString());
    }
}
