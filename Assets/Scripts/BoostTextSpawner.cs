using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTextSpawner : MonoBehaviour
{
    [SerializeField] BoostText boostTextPrefab = null;
 
    public void Spawn(float boostAmount)
    {
        BoostText instance = Instantiate<BoostText>(boostTextPrefab, transform);
        instance.SetValue(boostAmount);
    }
   
}
