using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable
{
    public Vector3 direction;
    public override void Interact()
    {
        Debug.Log("Object pushed");
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000.0f, ForceMode.Force);
    }

    void Update()
    {
        if(inZone && Input.GetKeyDown(KeyCode.Q))
        {
            Interact();
        }
    }
}
