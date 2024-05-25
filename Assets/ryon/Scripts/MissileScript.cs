using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float shootSpeed = 7f;
    public GameObject missilePoint;
    public GameObject missilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireMissile", 2.0f, shootSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireMissile()
    {
        Instantiate(missilePrefab, missilePoint.transform.position, Quaternion.identity);

    }
}
