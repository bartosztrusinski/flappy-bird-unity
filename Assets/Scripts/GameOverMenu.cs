using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
  private int bestScore;

  public GameObject GameOverPanel;
  public GameObject PauseButton;

  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI bestScoreText;

  public TextMeshProUGUI gameScore;

  void Awake()
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
      UpdateBestScore(score);
    }

    UpdateText(score);
  }

  private void UpdateText(int score)
  {
    scoreText.text = "Score: " + score.ToString();
    bestScoreText.text = "Best Score: " + bestScore.ToString();
  }

  private void UpdateBestScore(int newBestScore)
  {
    bestScore = newBestScore;
    PlayerPrefs.SetInt("BestScore", newBestScore);
  }

  public void RestartGame()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Game");
  }
}
