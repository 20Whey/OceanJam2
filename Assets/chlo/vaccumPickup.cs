using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class vaccumPickup : MonoBehaviour
{

    public float rad;
    [SerializeField] Collider[] nearbyColliders;
    // Start is called before the first frame update

    public IEnumerator moveToSucc(GameObject item)
    {
        var target = gameObject.transform;
        float elapsedTime = 0;
        float timeToMove = 5.0f;
        while (item.transform.position != target.position)
        {
            float t = elapsedTime / timeToMove;
            item.transform.position = new Vector3(Mathf.Lerp(item.transform.position.x, target.position.x, t), Mathf.Lerp(item.transform.position.y, target.position.y, t), Mathf.Lerp(item.transform.position.z, target.position.z, t));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(item);
    }

    public int returnExperience(params Collider[] colliders)
    {
        int val = 0;
        foreach (var item in colliders)
        {
            bool bol = false;
            GameObject gm = item.gameObject;
            switch (gm.tag)
            {
                case "common":
                    val += 1;
                    bol = true;
                    break;

                case "rare":
                    val = 2;
                    bol = true;
                    break;

                case "epic":
                    val = 5;
                    bol = true;
                    break;
            }
            if (bol == true)
            {
                StartCoroutine(moveToSucc(gm));
            }
        }
        return val;
    }


    void Update()
    {
        nearbyColliders = Physics.OverlapSphere(transform.position, rad, 3);
        if (nearbyColliders != null)
        {
            GameObject.Find("Canvas").transform.GetChild(0).GetComponent<PlayerExp>().AddExperience(returnExperience(nearbyColliders));
        }
    }
}
