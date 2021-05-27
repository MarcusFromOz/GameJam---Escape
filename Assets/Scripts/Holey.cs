using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holey : MonoBehaviour
{
    [SerializeField] BoxCollider thisHole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().currentLevel -= 1;
        }
    }

}
