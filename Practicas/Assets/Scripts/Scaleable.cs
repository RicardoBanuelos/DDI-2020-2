using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaleable : Interactable
{
    public Vector3 changeScale;
    bool addSub;

    public override void Interact()
    {
        Debug.Log("Object scaled");
        if(addSub)
            transform.localScale += changeScale;
        else
            transform.localScale -= changeScale;
    }

    void Update()
    {
        if(inZone)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                addSub = true;
                Interact();
            }
            else if(Input.GetKeyDown(KeyCode.Z))
            {
                addSub = false;
                Interact();
            }
        }
    }
}
