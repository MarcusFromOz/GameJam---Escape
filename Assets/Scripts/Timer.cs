using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Scoreboards;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;

    public TextMeshProUGUI timeText;

    [SerializeField] GameManager gameManager;

    [SerializeField] PlayerController myPlayerController;
    [SerializeField] Scoreboard myScoreboard;
    [SerializeField] LevelLoad myLevelLoad;

    AudioSource myAudioSource;
    bool playSound = true;

    private void Start()
    {
        timerIsRunning = true;
        myAudioSource = GetComponent<AudioSource>();
        timeRemaining = 300;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                //Do other things based on the time remaining
                // 1. Make the lights darker

                float intensity = (timeRemaining / 75) - 1;
                gameManager.SetLighting(intensity > 0 ? intensity : 0);

                // 2. Music? Sounds? UI?
                if (timeRemaining < 240 && playSound == true)
                {
                    myAudioSource.Play();
                    playSound = false;
                }
            }
            else
            {
                //do something to indicate time has run out
                
                timeRemaining = 0;
                timerIsRunning = false;

                // Stop the player from moving
                myPlayerController.isDead = true;

                // Show the high scores
                myScoreboard.enabled = true;

                // Go back to the start screen
                myLevelLoad.LoadStartScene(10);

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
