using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject teleporter;
    [SerializeField] GameObject level1StartPosition;
    [SerializeField] GameObject level2StartPosition;
    [SerializeField] GameObject level3StartPosition;
    [SerializeField] GameObject level4StartPosition;
    [SerializeField] GameObject level5StartPosition;

    [SerializeField] Timer myTimer;

    [SerializeField] GameManager gameManager;
    
    private void Start()
    {
        myTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        //gameManager = gameObject.GetComponent<GameManager>();
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
                //End Game
                // - Freeze Timer
                myTimer.timerIsRunning = false;

                //gameManager.SetLighting(10f);

                // - Show the high scores and how you went

                // - If a high score, save it

                // - Show a button to play again or go to the title screen

                // For now just go back to the main screen
                //other.GetComponent<PlayerController>().currentLevel = 1;
                //other.gameObject.transform.position = level1StartPosition.transform.position;
            }
        }
    }
}