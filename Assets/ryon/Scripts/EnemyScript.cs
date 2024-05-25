using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject expDrop;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
         //   TakeDamage(10); // Add 10 experience points when the space key is pressed
        //}
    }
   

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(expDrop, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    
}
