using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumPickup : MonoBehaviour
{
    public float rad;
    [SerializeField] Collider[] nearbyColliders;
    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    public IEnumerator MoveToSucc(GameObject item)
    {
        var target = gameObject.transform;
        float elapsedTime = 0;
        float timeToMove = 25.0f;

        while (item.transform.position != target.position)
        {
            float t = elapsedTime / timeToMove;
            item.transform.position = new Vector3(
                Mathf.Lerp(item.transform.position.x, target.position.x, t),
                Mathf.Lerp(item.transform.position.y, target.position.y, t),
                Mathf.Lerp(item.transform.position.z, target.position.z, t)
            );
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(item);
    }

    public int ReturnExperience(params Collider[] colliders)
    {
        int val = 0;

        foreach (var item in colliders)
        {
            if (collectedItems.Contains(item.gameObject)) continue;

            bool isCollectible = false;
            GameObject gm = item.gameObject;

            switch (gm.tag)
            {
                case "common":
                    val += 1;
                    isCollectible = true;
                    break;
                case "rare":
                    val += 2;
                    isCollectible = true;
                    break;
                case "epic":
                    val += 5;
                    isCollectible = true;
                    break;
            }

            if (isCollectible)
            {
                collectedItems.Add(gm);
                StartCoroutine(MoveToSucc(gm));
            }
        }

        return val;
    }

    void Update()
    {
        nearbyColliders = Physics.OverlapSphere(transform.position, rad);

        if (nearbyColliders.Length > 0)
        {
            int experienceToAdd = ReturnExperience(nearbyColliders);
            GameObject.Find("Canvas").transform.GetChild(0).GetComponent<PlayerExp>().AddExperience(experienceToAdd);
        }
    }
}