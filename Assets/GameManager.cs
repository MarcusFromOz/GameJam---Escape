using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] myLights;
    

    public void SetLighting(float myIntensity)
    {
        myLights = GameObject.FindGameObjectsWithTag("Light");

        foreach (GameObject light in myLights)
        {
            light.gameObject.GetComponent<Light>().intensity = myIntensity;
        }
    }

}
