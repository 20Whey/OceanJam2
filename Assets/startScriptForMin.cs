using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScriptForMin : MonoBehaviour
{

    public float vel;
    public GameObject targ;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.LookAt(targ.transform.position);
        rb.AddForce(transform.forward * vel * 30);
        rb.AddTorque(-transform.up * 3f * Random.Range(10, 20));
        rb.AddTorque(transform.right * 3f * Random.Range(10, 20));
    }


    
void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            Debug.Log("" + contact.point);
/*
code for cancelling player movement
*/

        }
        if (collision.relativeVelocity.magnitude > 2)
          Debug.Log("hit em hard"); 
          //  audioSource.Play();
         
    }





}
