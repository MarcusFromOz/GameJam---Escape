using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    //[SerializeField] CinemachineVirtualCamera virtualCamera;
    
    void Update()
    {
        transform.forward = Camera.main.transform.forward;    
    }
}
