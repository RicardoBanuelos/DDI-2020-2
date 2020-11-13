using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
            if(CrossPlatformInputManager.GetButtonDown("Oversize"))
            {
                addSub = true;
                Interact();
            }
            else if(CrossPlatformInputManager.GetButtonDown("Undersize"))
            {
                addSub = false;
                Interact();
            }
        }
    }
}
