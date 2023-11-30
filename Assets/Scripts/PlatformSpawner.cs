using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Vector3 platformSize;

    Vector3 nextPlatformPosition;

	private void Awake()
	{
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
		nextPlatformPosition += spawnX ? Vector3.right * platformSize.x : Vector3.forward * platformSize.z;
	}
}
