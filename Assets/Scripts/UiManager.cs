using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject inGame;

    [SerializeField] TMP_Text highScoreTextMenu;
    [SerializeField] TMP_Text highScoreTextGameOver;
    [SerializeField] TMP_Text scoreTextGameOver;
	[SerializeField] TMP_Text scoreTextInGame;

	public static UiManager instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		OnReset();	
	}

	void HideAllUi()
	{
		mainMenu.SetActive(false);
		gameOver.SetActive(false);
		inGame.SetActive(false);
	}

	public void GameStart()
	{
		HideAllUi();
		inGame.SetActive(true);
	}

	public void GameOver()
	{
		HideAllUi();
		gameOver.SetActive(true);

		scoreTextGameOver.text = ScoreManager.instance.GetScore().ToString();
		highScoreTextGameOver.text = ScoreManager.instance.GetHighScore().ToString();
	}

	public void OnReset()
	{
		HideAllUi();
		mainMenu.SetActive(true);
		highScoreTextMenu.text = "High Score: " + ScoreManager.instance.GetHighScore().ToString();
	}

	public void UpdateInGameScore()
	{
		scoreTextInGame.text = "Score: " + ScoreManager.instance.GetScore().ToString();
	}
}
