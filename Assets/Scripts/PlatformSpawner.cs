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
