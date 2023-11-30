using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

	static int score = 0;
	static int highScore = 0;

	private void Awake()
	{
		instance = this;
	}

	public void StartScore()
	{
		score = 0;
	}

	public void IncrementScore()
	{
		++score;
		UiManager.instance.UpdateInGameScore();
	}

	public int GetScore()
	{
		return score;
	}

	public int GetHighScore()
	{
		if (score > highScore)
			highScore = score;

		return highScore;
	}
}
