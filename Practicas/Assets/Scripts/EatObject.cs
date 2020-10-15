using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatObject : Interactable
{
    public override void Interact()
    {
        Debug.Log("Object eaten.");
        Object.Destroy(this.gameObject);
    }

    void Update()
    {
        if(inZone && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}
