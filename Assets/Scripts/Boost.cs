using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boost : MonoBehaviour
{
    private float speedBoost;
    [SerializeField] AudioSource speedBoostSound;
    [SerializeField] AudioSource badSpeedBoostSound;


    [SerializeField] BoostTextSpawner boostText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speedBoost = Random.Range(-6.0f, 8.0f);
            
            boostText.Spawn(speedBoost);

            other.GetComponent<PlayerController>().maxForwardSpeed += speedBoost;

            if (speedBoost > 0)
            {
                speedBoostSound.Play();
            }
            else
            {
                badSpeedBoostSound.Play();
            }

            other.GetComponent<PlayerController>().DisplaySpeed(other.GetComponent<PlayerController>().maxForwardSpeed);

            Destroy(gameObject, 0.5f);
        }
    }
}
