 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    [Header("User Interface")]
    public Text totalPointsText;
    public Text totalGamesText;
    public Text gamesWonText;
    public Text gamesLostText;
    public Text dayStreakText;

    // Start is called before the first frame update
    void Start(){
        totalPointsText.text = PlayerPrefs.GetInt("TotalPoints").ToString();
        totalGamesText.text = PlayerPrefs.GetInt("GamesPlayed").ToString();
        gamesWonText.text = PlayerPrefs.GetInt("GamesWon").ToString();
        gamesLostText.text = PlayerPrefs.GetInt("GamesLost").ToString();
        dayStreakText.text = PlayerPrefs.GetInt("DayStreak").ToString();
    }
}
