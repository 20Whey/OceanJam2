using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public PlayerStats stats;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = stats.playerMaxHealth;
        healthSlider.value = stats.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(10); // Add 10 experience points when the space key is pressed
        }
    }

    public void TakeDamage(int damage)
    {
        stats.playerHealth -= damage;
        updateNewHealth();
        if(stats.playerHealth <= 0)
        {
            Debug.Log("dead");
        }

    }

    public void updateNewHealth()
    {
        healthSlider.value = stats.playerHealth;
        healthSlider.maxValue = stats.playerMaxHealth;

    }



}
