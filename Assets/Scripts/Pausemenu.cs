using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public void ResumeResume()
  {
    Time.timeScale = 1f;
  }

  public void PausePause()
  {
    Time.timeScale = 0f;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu3D");

  }

  public void QuitGame()
  {
    Debug.Log("Quit Game");
    Application.Quit();
  }
}
