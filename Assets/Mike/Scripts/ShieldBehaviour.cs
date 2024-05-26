using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
	public PlayerStats playerStats;
	public GameObject player;

	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			if (gameObject.GetComponent<MeshRenderer>().enabled == true) 
			{
				StartCoroutine(ShieldBreak());		
			}
		}
	}

	IEnumerator ShieldBreak()
	{
		player.GetComponent<BoxCollider>().enabled = false;
		yield return new WaitForSeconds(1f);
		player.GetComponent<BoxCollider>().enabled = true;
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(10f);
		gameObject.GetComponent<MeshRenderer>().enabled = true;
	}
}
