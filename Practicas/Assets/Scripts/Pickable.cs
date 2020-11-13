using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Pickable : Interactable
{

    public int id;
    public Inventory inventory;

    void Start()
    {
        
    }
    public override void Interact()
    {
        inventory.GiveItem(id);
        Object.Destroy(this.gameObject);
    }

    void Update()
    {
        if(inZone && CrossPlatformInputManager.GetButtonDown("Collect"))
            Interact();
    }
}