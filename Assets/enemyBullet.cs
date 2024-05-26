using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
   	[SerializeField] private float destroyTime = 1f;
	private Coroutine _returnToPoolTimer;
	public PlayerStats playerStats;
	public sillyStuff SillyStuff;

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
		if (collision.transform.tag == "Player")
		{
			collision.gameObject.GetComponent<EnemyScript>().TakeDamage((int)SillyStuff.dmg);
			//playerController.Heal(playerStats.playerDamage * playerStats.playerLifeSteal);
			ObjectPoolManager.ReturnObjectToPool(gameObject);
		}
	}
}
