using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] float speed = 2;

	bool shouldFollow = true;
	Vector3 targetPos;

	private void Update()
	{
		if (shouldFollow)
			targetPos = target.position;

		transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
	}

	public void StopFollow()
	{
		shouldFollow = false;
	}
}
