using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boost : MonoBehaviour
{
    private float speedBoost;
    [SerializeField] AudioSource speedBoostSound;

    [SerializeField] BoostTextSpawner boostText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speedBoost = Random.Range(-2.0f, 4.0f);
            //Debug.Log(speedBoost);

            boostText.Spawn(speedBoost);

            other.GetComponent<PlayerController>().maxForwardSpeed += speedBoost;

            speedBoostSound.Play();

            other.GetComponent<PlayerController>().DisplaySpeed(other.GetComponent<PlayerController>().maxForwardSpeed);

            Destroy(gameObject, 0.5f);
        }
    }
}
