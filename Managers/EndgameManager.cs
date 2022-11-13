using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameManager : MonoBehaviour
{
    [Header("User Interface")]
    public Text pointsScored;
    public Text movieTitle;

    // Start is called before the first frame update
    void Start(){
        pointsScored.text = "+" + GameData.pointsTransfer.ToString();
        //PlayerPrefs.SetString("MovieToday", GameData.movieTransfer);
        movieTitle.text = PlayerPrefs.GetString("MovieToday").ToString();
        Debug.Log(PlayerPrefs.GetString("MovieToday"));

        lockDaySeed();
    }

    public int GetDateSeed(){
        var dateToday = System.DateTime.UtcNow;
        var endOfYear = new System.DateTime(dateToday.Year + 000, 08, 07);
        var diff = endOfYear - dateToday;
        return (int)diff.TotalDays;
    }

    void lockDaySeed(){
        if(PlayerPrefs.GetInt("Word Of The Day") != GetDateSeed()){
            PlayerPrefs.SetInt("Word Of The Day", GuessManager.itemCount); 
        }
    }
}
