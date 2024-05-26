using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rand = UnityEngine.Random;
public class bubbleBehav : MonoBehaviour
{

    private Rigidbody rb;
    public Transform targ;
    public float rad;
    public Collider[] nearbyColliders;

    // Start is called before the first frame update
    public IEnumerator moveToSucc(GameObject item)
    {
        item.GetComponent<sillyStuff>().isBub = true;
        var target = gameObject.transform;
        float elapsedTime = 0f;
        float timeToMove = 3.0f;
        while (elapsedTime < timeToMove)
        {
            float t = elapsedTime / timeToMove;
            item.transform.position = new Vector3(Mathf.Lerp(item.transform.position.x, target.position.x, t), Mathf.Lerp(item.transform.position.y, target.position.y, t), Mathf.Lerp(item.transform.position.z, target.position.z, t));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        item.GetComponent<turmoil>().targ = new Vector3((float)rand.Range(-10, 10), (float)rand.Range(-10, 10), 0f);
        item.GetComponent<turmoil>().turm(3f);
        
    }

    void Start()
    {
        targ = GameObject.Find("Player").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.LookAt(targ.transform.position);
        rb.AddForce(transform.forward * 1f * 30);
        rb.AddTorque(-transform.up * 3f * rand.Range(10, 20));
        rb.AddTorque(transform.right * 3f * rand.Range(10, 20));
    }
    private void doBubble(params Collider[] colliders)
    {
        foreach (var item in colliders)
        {
           /* if (item.gameObject.tag != "hasBubbled" && item.gameObject.tag == "canBubble")
            {*/
                if (item.gameObject.GetComponent<sillyStuff>() != null){
                if(!item.gameObject.GetComponent<sillyStuff>().isBub)
                 StartCoroutine(moveToSucc(item.gameObject));
                }
            //}
        }
    }
    void Update()
    {
        nearbyColliders = Physics.OverlapSphere(transform.position, rad, 7);

        if (nearbyColliders != null)
        {
            doBubble(nearbyColliders);
        }

    }
    // Update is called once per frame

}

