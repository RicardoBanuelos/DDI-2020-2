using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    // Update is called once per frame
    void OnMouseDown()
    {
        Object.Destroy(this.gameObject);
    }
}
