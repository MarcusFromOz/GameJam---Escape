using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostText : MonoBehaviour
{
    [SerializeField] Text boostText = null;

    public void DestroyText()
    {
        Destroy(gameObject);
    }

    public void SetValue(float amount)
    {
        boostText.text = String.Format("{0:F2}", amount);
    }

}
