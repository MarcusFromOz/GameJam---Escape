using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;

    public TextMeshProUGUI timeText;

    [SerializeField] GameManager gameManager;
    AudioSource myAudioSource;
    bool playSound = true;

    private void Start()
    {
        timerIsRunning = true;
        myAudioSource = GetComponent<AudioSource>();
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
                // 1. show high score table

                // 2. lock movement 


                timeRemaining = 0;
                timerIsRunning = false;
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
