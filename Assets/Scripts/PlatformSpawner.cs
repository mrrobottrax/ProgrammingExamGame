using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	[SerializeField] GameObject platformPrefab;
	[SerializeField] GameObject diamondPrefab;
	[SerializeField] Vector3 platformSize;
	[SerializeField] float spawnDelay = 0.2f;
	[SerializeField] float diamondChance = 0.5f;

	Vector3 nextPlatformPosition;

	WaitForSeconds spawnTimer;

	Coroutine spawnRoutine;

	private void Awake()
	{
		spawnTimer = new WaitForSeconds(spawnDelay);

		nextPlatformPosition = transform.position;

		for (float i = 0; i < 20; ++i)
		{
			SpawnPlatform();
		}
	}

	void SpawnPlatform()
	{
		Instantiate(platformPrefab, nextPlatformPosition, Quaternion.identity);
		bool spawnX = Random.value > 0.5;

		if (Random.value < diamondChance)
		{
			SpawnDiamond();
		}

		nextPlatformPosition += spawnX ? Vector3.right * platformSize.x : Vector3.forward * platformSize.z;
	}

	void SpawnDiamond()
	{
		Vector3 position = nextPlatformPosition + new Vector3(
			Random.Range(-platformSize.x / 2, platformSize.x / 2),
			0,
			Random.Range(-platformSize.z / 2, platformSize.z / 2)
		);
		Instantiate(diamondPrefab, position, Quaternion.identity);
	}

	public void StartSpawning()
	{
		spawnRoutine = StartCoroutine(SpawnLoop());
	}

	public void StopSpawning()
	{
		StopCoroutine(spawnRoutine);
	}

	IEnumerator SpawnLoop()
	{
		yield return spawnTimer;

		SpawnPlatform();

		spawnRoutine = StartCoroutine(SpawnLoop());
	}
}
