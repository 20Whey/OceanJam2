using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MonoBehaviour
{
	public PlayerStats playerStats;
	public PlayerController playerController;

	void OnTriggerEnter(Collider collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyScript>().TakeDamage((int)playerStats.playerDamage);
			playerController.Heal(playerStats.playerDamage * playerStats.playerLifeSteal);
			collision.gameObject.GetComponent<turmoil>().turm(2f);
		}
	}
}
