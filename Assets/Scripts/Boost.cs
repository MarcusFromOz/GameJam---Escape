using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private float speedBoost;
    [SerializeField] AudioSource speedBoostSound;
      
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speedBoost = Random.Range(-2.0f, 2.0f);
            Debug.Log(speedBoost);

            other.GetComponent<PlayerController>().moveSpeed += speedBoost;

            speedBoostSound.Play();

            other.GetComponent<PlayerController>().DisplaySpeed(other.GetComponent<PlayerController>().moveSpeed);

            Destroy(gameObject, 0.5f);
        }
    }
}
