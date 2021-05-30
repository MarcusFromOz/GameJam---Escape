using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeBoost : MonoBehaviour
{
    private float timeBoost;
    [SerializeField] TextMeshProUGUI timeText;
    
    [SerializeField] BoostTextSpawner boostText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timeBoost = Random.Range(-5.0f, 20.0f);
            //Debug.Log("timeBoost: "+ timeBoost);
            
            boostText.Spawn(timeBoost);

            timeText.GetComponent<Timer>().timeRemaining += timeBoost;

            //no need to trigger timer - is running through the timer update method anyway
            //other.GetComponent<PlayerController>().DisplaySpeed(other.GetComponent<PlayerController>().moveSpeed);

            Destroy(gameObject, 0.5f);
        }
    }
}
