using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] UiManager uiManager;
	[SerializeField] CameraFollow cameraFollow;
	[SerializeField] PlatformSpawner platformSpawner;

	public static GameManager singleton;

	private void Awake()
	{
		singleton = this;
	}

	public void OnPlayerFall()
	{
		cameraFollow.StopFollow();
		platformSpawner.StopSpawning();
	}

	public void OnGameStart()
	{
		uiManager.HideStartText();
		platformSpawner.StartSpawning();
	}
}
