using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth playerHealth;
    
    void Start(){

    }

    void Update(){
        healthBar.value = playerHealth.health;
    }
}
