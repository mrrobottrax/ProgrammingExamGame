using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] float fallDelay;
	[SerializeField] float despawnDelay;
	[SerializeField] Rigidbody rb;
	[SerializeField] Vector3 angularVelocityRange;

	static WaitForSeconds fallTimer;

	private void Awake()
	{
		if (fallTimer == null)
			fallTimer = new WaitForSeconds(fallDelay);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(FallTimer());
			Destroy(gameObject, despawnDelay);
		}
	}

	IEnumerator FallTimer()
	{
		yield return fallTimer;

		rb.useGravity = true;
		rb.constraints = RigidbodyConstraints.None;

		rb.angularVelocity = new Vector3(
			Random.Range(-angularVelocityRange.x, angularVelocityRange.x),
			Random.Range(-angularVelocityRange.y, angularVelocityRange.y),
			Random.Range(-angularVelocityRange.z, angularVelocityRange.z)
		);
	}
}
