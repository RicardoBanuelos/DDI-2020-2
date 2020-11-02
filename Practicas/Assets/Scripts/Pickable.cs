using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{

    public KeyCode keyCode;

    void Start()
    {
        
    }
    public override void Interact()
    {
        Debug.Log("Coin collected.");
        Object.Destroy(this.gameObject);
    }

    void Update()
    {
        if(inZone && Input.GetKeyDown(keyCode))
            Interact();
    }
}