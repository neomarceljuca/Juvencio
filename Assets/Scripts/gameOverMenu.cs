using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public GameObject GameOverMenuUi;
    public Player myPlayer;
    //private bool GameisPaused;


    void Update()
    {

        if (myPlayer.gameOver)
        {
            GameOverMenuUi.SetActive(true);
            Time.timeScale = 0f;
            //GameisPaused = true;
            
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
