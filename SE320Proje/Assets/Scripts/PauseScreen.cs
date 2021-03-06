﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pausePanel;
    private bool pausePanelActive;

    public void resume()
    {
        if (NaviCursor.pMenu == false && TowerCursor.sellUpgradePanelOpen == false)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
        pausePanel.SetActive(false);
        pausePanelActive = false;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        Money.money = 1000;
        Lives.life = 20;
        Timer.second = 0f;
        Timer.minute = 0;
        SniperTower.sniperTowerLevelCnt = 2;
        RapidTurret.rapidTowerLevelCnt = 2;
        Turret.towerLevelCnt = 2;
        SniperTower.sniperTowerLevel = 1;
        RapidTurret.rapidTowerLevel = 1;
        Turret.towerLevel = 1;
    }

    public void quitMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        pausePanelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanelActive)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                pausePanelActive = true;
                Cursor.visible = true;
            }
            else
            {
                resume();
            }
            
        }
    }
}
