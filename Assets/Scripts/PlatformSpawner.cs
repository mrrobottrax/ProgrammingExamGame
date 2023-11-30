using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	[SerializeField] bool useTimer = true;
	[SerializeField] GameObject platformPrefab;
	[SerializeField] GameObject diamondPrefab;
	[SerializeField] Vector3 platformSize;
	[SerializeField] float spawnDelay = 0.2f;
	[SerializeField] float diamondChance = 0.5f;

	Vector3 nextPlatformPosition;

	WaitForSeconds spawnTimer;

	Coroutine spawnRoutine;

	const int startPlatformCount = 50; // I know it's supposed to be 20, but I prefer 50
	private void Awake()
	{
		spawnTimer = new WaitForSeconds(spawnDelay);

		nextPlatformPosition = transform.position;

		for (float i = 0; i < startPlatformCount; ++i)
		{
			SpawnPlatformInternal();
		}
	}

	public void TrySpawnPlatform()
	{
		if (!useTimer)
			SpawnPlatformInternal();
	}

	void SpawnPlatformInternal()
	{
		GameObject platform = Instantiate(platformPrefab, nextPlatformPosition, Quaternion.identity);
		bool spawnX = Random.value > 0.5;

		if (Random.value < diamondChance)
		{
			SpawnDiamond(platform.transform);
		}

		nextPlatformPosition += spawnX ? Vector3.right * platformSize.x : Vector3.forward * platformSize.z;
	}

	void SpawnDiamond(Transform parent)
	{
		Vector3 position = nextPlatformPosition + new Vector3(
			Random.Range(-platformSize.x / 2, platformSize.x / 2),
			0,
			Random.Range(-platformSize.z / 2, platformSize.z / 2)
		);

		GameObject diamond = Instantiate(diamondPrefab, parent, true);

		diamond.transform.position = position;
	}

	public void StartSpawning()
	{
		if (useTimer)
			spawnRoutine = StartCoroutine(SpawnLoop());
	}

	public void StopSpawning()
	{
		if (useTimer)
			StopCoroutine(spawnRoutine);
	}

	IEnumerator SpawnLoop()
	{
		yield return spawnTimer;

		SpawnPlatformInternal();

		spawnRoutine = StartCoroutine(SpawnLoop());
	}
}
