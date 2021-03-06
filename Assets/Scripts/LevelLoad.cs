using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoad : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 5;
    [SerializeField] GameManager gameManager;
    
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadEasyMode()
    {
        gameManager.easyMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartSceneNow()
    {
        gameManager.easyMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartScene(int delay)
    {
        gameManager.easyMode = false;
        StartCoroutine(WaitForStartScreen(delay));
    }

    public void Quit()
    {
        Application.Quit();
    }


    IEnumerator WaitForStartScreen(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }

}
