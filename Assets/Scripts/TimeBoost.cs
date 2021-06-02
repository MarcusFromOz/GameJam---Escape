using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeBoost : MonoBehaviour
{
    private float timeBoost;
    
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] BoostTextSpawner boostText;
    [SerializeField] AudioSource timeBoostSound;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            timeBoost = Random.Range(-30.0f, 40.0f);

            boostText.Spawn(timeBoost);
            timeBoostSound.Play();

            timeText.GetComponent<Timer>().SetTimeRemaining(timeBoost);
            
            Destroy(gameObject, 0.5f);
        }
    }
}
