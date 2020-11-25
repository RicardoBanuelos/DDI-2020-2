using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    public Transform player;
    public Vector3 heightOffset;
    public void TeleportPlayer(Vector3 newPos)
    {
        player.position = newPos + heightOffset;
    }

}
