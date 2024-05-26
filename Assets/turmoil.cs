using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turmoil : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float vel;
    public bool turnToReg;
    public Vector3 targ;

    private IEnumerator Return(float del, float spd)
    {
        float elpsedT = 0f;
        rb.angularDrag = 7f;
        while (elpsedT < del)
        {
            float singleStep = spd * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.eulerAngles, new Vector3(0, 0, 0), singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            //transform.rotation = nR;
            elpsedT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        rb.angularVelocity = Vector3.zero;
        gameObject.GetComponent<sillyStuff>().tm = false;

       // rb.angularDrag = 3f;
      /* Vector3 eulerAngles = transform.eulerAngles;
		transform.eulerAngles = new Vector3( eulerAngles.x , 0f , eulerAngles.z );*/
    }


    private IEnumerator Delay(float del)
    {
        float elpsedT = 0f;
        while (elpsedT < del)
        {
            elpsedT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Return(3f, 1f));
    }
    public void turm(float del)
    {
        gameObject.GetComponent<sillyStuff>().tm = true;
        gameObject.transform.LookAt(targ);
        rb.AddForce(transform.forward * vel * 30);
        if (gameObject.name.Contains("Enemy")){
        rb.AddTorque(-transform.up * 3f * Random.Range(-10, 10));
        rb.AddTorque(transform.right * 3f * Random.Range(-10, 10));
        }
        StartCoroutine(Delay(del));
    }
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (turnToReg == true)
        {
            StartCoroutine(Return(3f, 0.1f));
            turnToReg = false;
            
        }
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targ, singleStep, 0.0f);
        if (transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            rb.angularVelocity = Vector3.zero;
        }*/
    }
}