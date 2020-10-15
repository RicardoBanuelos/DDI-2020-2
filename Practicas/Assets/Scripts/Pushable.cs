using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable
{
    Rigidbody rb;
    public float pushForce;

    public override void Interact()
    {
        Debug.Log("Object pushed");
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * pushForce);
    }

    void Update()
    {
        if(inZone && Input.GetKeyDown(KeyCode.Q))
        {
            Interact();
        }
    }
}
