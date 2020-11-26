using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaleable : MonoBehaviour
{
    public Vector3 scale;   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            transform.localScale+=scale;
        else if(Input.GetMouseButtonDown(1))
            transform.localScale-=scale;
    }
}
