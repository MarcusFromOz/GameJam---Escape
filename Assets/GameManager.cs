using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] myLights;

    GameObject myScoreboardCanvas;

    public bool easyMode = false;

    private void Start()
    {
        if (easyMode == false)
        {
            // If not easyMode then limit exits to one per level
            ChooseEnabledExits("Level1Exit");
            ChooseEnabledExits("Level2Exit");
            ChooseEnabledExits("Level3Exit");
            ChooseEnabledExits("Level4Exit");
        }

        myScoreboardCanvas = GameObject.FindWithTag("ScoreboardCanvas");
        myScoreboardCanvas.SetActive(false);
    }


    private void ChooseEnabledExits(string levelNumber)
    {
        GameObject[] levelExits;
        int index;

        levelExits = GameObject.FindGameObjectsWithTag(levelNumber);
        index = Random.Range(0, levelExits.Length);

        foreach(GameObject exit in levelExits)
        {
                exit.SetActive(false);
        }
        levelExits[index].SetActive(true);
    }


    public void SetLighting(float myIntensity)
    {
        myLights = GameObject.FindGameObjectsWithTag("Light");

        foreach (GameObject light in myLights)
        {
            light.gameObject.GetComponent<Light>().intensity = myIntensity;
        }
    }

}
