using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Vector3 rotate;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            transform.Rotate(rotate);
        else if(Input.GetMouseButtonDown(1))
            transform.Rotate(rotate*-1);
    }
}
