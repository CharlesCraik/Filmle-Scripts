using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuessManager : MonoBehaviour
{
    [Header("User Interface")]
    public Text quoteDisplay;
    public Text scrambledWordDisplay;
    public InputField guessInput;
    public Text[] previousGuess;
    public Image[] guessDisplay;

    private int slot = 4;

    [Header("Rules")]
    public int guessCounter = 5;
    public GameObject[] plates;

    [Header("Target Variables")]
    public GameObject itemDatabase;
    public static int itemCount = 0;
    public string movie;
    public string movieQuote;
    public string scrambledWord;

    private Text playerGuess;
    private string movieCheck;

    LoadExcel database;

    //System to change what item is chosen from database; achieved through countdown to certain date (06/08/2022)
    public int GetDateSeed(){
        var dateToday = System.DateTime.UtcNow;
        var endOfYear = new System.DateTime(dateToday.Year + 000, 08, 07);
        var diff = endOfYear - dateToday;
        Debug.Log(dateToday + " + " + endOfYear + " + " + diff + " + " + (int)diff.TotalDays);
        return (int)diff.TotalDays;
    }

    // Start is called before the first frame update
    void Start(){
        itemCount = GetDateSeed();
        playerGuess = guessInput.transform.Find("Text").GetComponent<Text>();
        database = itemDatabase.GetComponent<LoadExcel>();

        //Setting the answer (movie) and the relating quote
        movie = database.itemDatabase[itemCount].name;
        movieQuote = '"' + database.itemDatabase[itemCount].quote + '"';
        ScrambleWord();
        scrambledWordDisplay.text = scrambledWord.ToString();

        /*if(PlayerPrefs.GetInt("Word Of The Day") != itemCount){
            PlayerPrefs.SetInt("Word Of The Day", itemCount); 
        }*/

        quoteDisplay.text = movieQuote;
        movieCheck = movie.ToLower();

        GameData.movieTransfer = movie;
        if(PlayerPrefs.GetString("Show Guesses") == "False"){
            foreach(Image i in guessDisplay){
                i.transform.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            string answer = playerGuess.text.ToLower();
            if(answer == movieCheck){
               Debug.Log("Correct");
               PlayerPrefs.SetString("MovieToday", movie);
               PlayerPrefs.SetInt("Result", 1); //Saves result of the day || 1 = Win || 2 = Lose
               UpdateProfile();
               SceneManager.LoadScene("PlayerWins");
               GameData.pointsTransfer = guessCounter; 
            }
            else{
                previousGuess[slot].text = playerGuess.text;
                guessDisplay[slot].color = new Color32(246,118,49,255);

                guessCounter -= 1;
                slot -= 1;
                if(slot <= 3){
                    plates[slot].SetActive(false);
                }
                else if(slot <= 0){
                    ;
                }
            }
        }

        if(guessCounter <= 0){
            slot = 0;
            PlayerPrefs.SetString("MovieToday", movie);
            GameData.pointsTransfer = 0;
            PlayerPrefs.SetInt("Result", 2); //Saves result of the day || 1 = Win || 2 = Lose || 0 = Empty
            UpdateProfile();
            SceneManager.LoadScene("PlayerLoses");
        }
        
    }

    void ScrambleWord(){
        char[] myChar = movie.ToCharArray(); // Convert string to char array
        // Jumble char array 
        for (int i = myChar.Length - 1; i > 0; i--){
            int rnd = UnityEngine.Random.Range(0, i);
            char temp = myChar[i];
            if(temp != ' ' && myChar[rnd] != ' '){
                myChar[i] = myChar[rnd];
                myChar[rnd] = temp;
            }
        }

        var jumbledWord = new string(myChar);   // Convert char array to string 
        scrambledWord = jumbledWord;// Display jumbled word to screen
    }

    void UpdateProfile(){
        PlayerPrefs.SetInt("TotalPoints", PlayerPrefs.GetInt("TotalPoints") + guessCounter);
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);

        if(PlayerPrefs.GetInt("Result") == 1){ //Player has won
            PlayerPrefs.SetInt("GamesWon", PlayerPrefs.GetInt("GamesWon") + 1);
        }
        else if(PlayerPrefs.GetInt("Result") == 2){ //Player has lost
            PlayerPrefs.SetInt("GamesLost", PlayerPrefs.GetInt("GamesLost") + 1);
        }

        if(PlayerPrefs.GetInt("LastPlayed") == 0){
            PlayerPrefs.SetInt("LastPlayed", GetDateSeed());
            PlayerPrefs.SetInt("DayStreak", 1);
        }

        if((PlayerPrefs.GetInt("LastPlayed") - GetDateSeed()) == 1){
            PlayerPrefs.SetInt("DayStreak", PlayerPrefs.GetInt("DayStreak") + 1);
            PlayerPrefs.SetInt("LastPlayed", GetDateSeed());
        }
        else if((PlayerPrefs.GetInt("LastPlayed") - GetDateSeed()) > 1){
            PlayerPrefs.SetInt("DayStreak", 1);
            PlayerPrefs.SetInt("LastPlayed", GetDateSeed());
        }

    }

}
