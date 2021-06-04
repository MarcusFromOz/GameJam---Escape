using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundbox : MonoBehaviour
{
    [SerializeField] AudioSource soundbox;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            soundbox.Play();
        }
    }
}
