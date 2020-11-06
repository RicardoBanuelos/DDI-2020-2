using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{

    public KeyCode keyCode;
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
        if(inZone && Input.GetKeyDown(keyCode))
            Interact();
    }
}