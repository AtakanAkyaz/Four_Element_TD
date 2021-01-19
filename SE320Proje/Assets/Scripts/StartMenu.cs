using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    public void startGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        Money.money = 1000;
        Lives.life = 20;
        Timer.second = 0f;
        Timer.minute = 0;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
