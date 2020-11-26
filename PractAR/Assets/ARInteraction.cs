using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Rumm Rummm");
        Destroy(this.gameObject);
    }
    
}
