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
        rb.angularDrag = 0f;
    }


    private IEnumerator Delay(float del)
    {
        float elpsedT = 0f;
        while (elpsedT < del)
        {
            elpsedT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        turnToReg = true;
    }
    public void turm(float del)
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.LookAt(targ);
        rb.AddForce(transform.forward * vel * 30);
        rb.AddTorque(-transform.up * 3f * Random.Range(-10, 10));
        rb.AddTorque(transform.right * 3f * Random.Range(-10, 10));
        StartCoroutine(Delay(del));
    }
    void Awake()
    {
        //turm();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (turnToReg == true)
        {
            StartCoroutine(Return(3f, 0.1f));
            turnToReg = false;
        }
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targ, singleStep, 0.0f);
        if (transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            turnToReg = false;

        }
    }
}