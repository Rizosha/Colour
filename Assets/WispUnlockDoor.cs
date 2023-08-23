using System;
using System.Collections;
using System.Collections.Generic;
using Ash.Scripts;
using UnityEngine;

public class WispUnlockDoor : MonoBehaviour
{
    private DoorController doorC;

    private void Start()
    {
        doorC = GameObject.FindWithTag("Door").GetComponent<DoorController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WispParent"))
        {
            doorC.doorNo = 1;
        }
    }
}
