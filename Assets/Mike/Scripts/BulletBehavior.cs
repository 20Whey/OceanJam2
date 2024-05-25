using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	[SerializeField] private float destroyTime = 1f;
	private Coroutine _returnToPoolTimer;
	public EnemyScript enemyScript;
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
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			// do damage here, for example:
			collision.gameObject.GetComponent<EnemyScript>().TakeDamage(5);
		}
	}
}
