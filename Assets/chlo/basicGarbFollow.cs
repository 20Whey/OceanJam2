using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGarbFollow : MonoBehaviour
{
    // Start is called before the first frame update
  
    public Transform target;
    public Rigidbody rb;

    // Update is called once per frame

    void Awake() {
      rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
    //  Vector3 targetPostition = new Vector3( target.position.x , target.position.y, this.transform.position.z ) ;
     transform.LookAt( target ) ;
     rb.AddForce(transform.forward);
    }
}
