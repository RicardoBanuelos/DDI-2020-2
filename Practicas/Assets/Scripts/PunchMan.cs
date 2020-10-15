using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMan : Interactable
{


    public override void Interact()
    {
        Debug.Log("Man Punched");
        
    }



    void Update()
    {
        if(inZone && Input.GetKeyDown(KeyCode.E))
            Interact();
    }
}

