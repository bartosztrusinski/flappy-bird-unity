using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverMenu : MonoBehaviour
{
  private static int bestScore;

  public GameObject GameOverPanel;
  public GameObject PauseButton;

  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI bestScoreText;

  public TextMeshProUGUI gameScore;

  void Start()
  {
    bestScore = PlayerPrefs.GetInt("BestScore", 0);
  }

  public void GameOver()
  {
    int score = int.Parse(gameScore.text);

    GameOverPanel.SetActive(true);
    PauseButton.SetActive(false);
    Time.timeScale = 0f;

    if (score > bestScore)
    {
      SetNewBestScore(score);
    }

    UpdateText(score);
  }

  private void UpdateText(int score)
  {
    scoreText.text = "Score: " + score.ToString();
    bestScoreText.text = "Best Score: " + bestScore.ToString();
  }

  private void SetNewBestScore(int newBestScore)
  {
    bestScore = newBestScore;
    PlayerPrefs.SetInt("BestScore", newBestScore);
  }

  public void RestartGame()
  {
    // GameOverPanel.SetActive(false);
    // PauseButton.SetActive(true);
    Time.timeScale = 1f;
    SceneManager.LoadScene("Game");
  }
}
