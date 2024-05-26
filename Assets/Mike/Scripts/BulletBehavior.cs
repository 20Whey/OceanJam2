using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	[SerializeField] private float destroyTime = 1f;
	private Coroutine _returnToPoolTimer;
	public PlayerStats playerStats;
	public PlayerController playerController;

	private void OnEnable()
	{
		_returnToPoolTimer = StartCoroutine(ReturnToPoolDelayed());
	}
	private IEnumerator ReturnToPoolDelayed()
	{
		float elapsedTime = 0f;
		while(elapsedTime < destroyTime)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		ObjectPoolManager.ReturnObjectToPool(gameObject);
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyScript>().TakeDamage((int)playerStats.playerDamage);
			playerController.Heal(playerStats.playerDamage * playerStats.playerLifeSteal);
			ObjectPoolManager.ReturnObjectToPool(gameObject);
		}
	}
}
