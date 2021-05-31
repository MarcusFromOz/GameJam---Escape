using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scoreboards;
using System;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject teleporter;
    [SerializeField] GameObject level1StartPosition;
    [SerializeField] GameObject level2StartPosition;
    [SerializeField] GameObject level3StartPosition;
    [SerializeField] GameObject level4StartPosition;
    [SerializeField] GameObject level5StartPosition;

    Timer myTimer;

    [SerializeField] GameManager gameManager;
    [SerializeField] Scoreboard myScoreboard;
    
    LevelLoad myLevelLoad;

    private void Start()
    {
        myTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        myScoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Scoreboard>();
        myLevelLoad = GameObject.Find("Level Loader").GetComponent<LevelLoad>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().currentLevel == 1)
            {
                other.GetComponent<PlayerController>().currentLevel = 2;
                other.gameObject.transform.position = level2StartPosition.transform.position;
            }
            else if (other.GetComponent<PlayerController>().currentLevel == 2)
            {
                other.GetComponent<PlayerController>().currentLevel = 3;
                other.gameObject.transform.position = level3StartPosition.transform.position;
            }
            else if (other.GetComponent<PlayerController>().currentLevel == 3)
            {
                other.GetComponent<PlayerController>().currentLevel = 4;
                other.gameObject.transform.position = level4StartPosition.transform.position;
            }
            else if (other.GetComponent<PlayerController>().currentLevel == 4)
            {
                other.GetComponent<PlayerController>().currentLevel = 5;
                other.gameObject.transform.position = level5StartPosition.transform.position;
            }
            else if (other.GetComponent<PlayerController>().currentLevel == 5)
            {
                // End the Game (You win !!)

                // Freeze Timer
                myTimer.timerIsRunning = false;

                // Stop the player from moving
                other.GetComponent<PlayerController>().isDead = true;

                // Show the high scores and how you went
                myScoreboard.transform.GetChild(0).gameObject.SetActive(true);

                // If a high score, save it
                ScoreboardEntryData newScoreboardEntry = new ScoreboardEntryData();

                newScoreboardEntry.entryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                newScoreboardEntry.entryScore = Mathf.Round(myTimer.timeRemaining);

                myScoreboard.AddEntry(newScoreboardEntry);

                // Go back to the start screen
                myLevelLoad.LoadStartScene(8);
            }
        }
    }
}
