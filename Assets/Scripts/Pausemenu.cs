using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{

    

    

    private void Update()
    {
        
    }


    public void ResumeResume()
    {
       
        Time.timeScale = 1f;
        
    }

    public void PausePause()
    {
       
        Time.timeScale = 0f;
        
    }

    public void Loadmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    public void Quitgame()
    {
        Debug.Log("Quit Game");
        Application.Quit();

    }

}
