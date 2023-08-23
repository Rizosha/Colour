using System;
using System.Collections;
using System.Collections.Generic;
using Ash.Scripts.Dialogue;
using UnityEngine;

public class BedLore : MonoBehaviour
{
    public bool canTalk = false;
    public Dialogue bDlg;

    private void Start()
    {
        bDlg = GameObject.FindWithTag("Bed").GetComponent<Dialogue>();
    }

    private void Update()
    {
        if (canTalk && Input.GetKey(KeyCode.E))
        {
            
            canTalk = false;
            bDlg.GenerateSentence();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
        }
    }

   
}
