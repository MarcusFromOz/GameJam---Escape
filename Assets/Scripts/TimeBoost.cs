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
    [SerializeField] AudioSource badTimeBoostSound;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            timeBoost = Random.Range(-30.0f, 40.0f);

            if (timeBoost < 0)
            {
                badTimeBoostSound.Play();
            }
            else
            {
                timeBoostSound.Play();
            }

            boostText.Spawn(timeBoost);
            
            timeText.GetComponent<Timer>().SetTimeRemaining(timeBoost);
            
            Destroy(gameObject, 0.5f);
        }
    }
}
