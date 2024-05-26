using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
	public Material mat;
	public float smoothAmount = 0f;
	float max = 0.3f;
	float min = 0f;
	public void Start()
	{
	}

	private void Update()
	{
		mat.SetFloat("_GlossMapScale", Mathf.Lerp(min, max, smoothAmount));
		smoothAmount += 0.5f * Time.deltaTime;

		if (smoothAmount > 1f)
		{
			float temp = max;
			max = min;
			min = temp;
			smoothAmount = 0.0f;
		}
	}
}
