using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] AudioSource doorOpeningSound;
    [SerializeField] ParticleSystem doorOpeningParticles;
    private void start()
    {
        doorOpeningSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Add some dust
            doorOpeningParticles.Play();

            //Add some sound
            doorOpeningSound.Play();

            Destroy(gameObject, 0.5f);

        }
    }
}
