using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : Interactable
{
    public override void Interact()
    {
        Debug.Log("Coin collected.");
        Object.Destroy(this.gameObject);
    }

    void Update()
    {
        if(inZone && Input.GetKeyDown(KeyCode.C))
            Interact();
    }
}
