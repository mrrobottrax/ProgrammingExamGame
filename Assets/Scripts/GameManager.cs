using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] CameraFollow cameraFollow;
	[SerializeField] PlatformSpawner platformSpawner;

	public static GameManager instance;

	private void Awake()
	{
		instance = this;
	}

	public void GameOver()
	{
		UiManager.instance.GameOver();
		cameraFollow.StopFollow();
		platformSpawner.StopSpawning();
	}

	public void GameStart()
	{
		UiManager.instance.GameStart();
		ScoreManager.instance.StartScore();
		platformSpawner.StartSpawning();
	}

	public void OnReset()
	{
		// Load scene again
		SceneManager.LoadScene(0);

		UiManager.instance.OnReset();
	}
}
