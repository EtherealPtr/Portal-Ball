using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TheGameManager : MonoBehaviour
{
    public static TheGameManager instance;
    public Text playerScoreText, levelText, winText, deathText;
    private static int iPlayerScore = 0, iTotalDeaths = 0, iLevel = 1;

    private void Awake()
    {
        // Only one instance of this class may exist (Singleton Design Pattern) 
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        winText.text = "";
    }

    public void IncrementPlayerScore(int bonusScore)
    {
        iPlayerScore += bonusScore;
    }

    public void IncrementLevel(int add)
    {
        iLevel += add;
    }

    public void IncrementDeath(int add)
    {
        iTotalDeaths += add;
    }

    // Function that displays the score and the level UI
    void DisplayUI()
    {
        playerScoreText.text = "Score: " + iPlayerScore.ToString();
        levelText.text = "Level: " + iLevel.ToString();
        deathText.text = "Death: " + iTotalDeaths.ToString();
    }

    void DisplayWinner()
    {
        winText.text = "Congratulation! You win!";
    }

    private void Update()
    {
        DisplayUI();

        if (iLevel >= 6)
        {
            DisplayWinner();
            RestartGameComponents();
        }
    }

    private void RestartGameComponents()
    {
        iPlayerScore = 0;
        iLevel = 1;
        iTotalDeaths = 0;
    }
}
