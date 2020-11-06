using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public void sendDamage(int damage){
        playerHealth.TakeDamage(damage);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.H))
            sendDamage(20);
    }
}
