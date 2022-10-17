using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject settingPopup;
    public GameObject gameOverPopup;
    public GameObject gameEndPopup;
    public GameObject gameExplainPopup;

    private void Update()
    {   
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (GameManager.instance.PlayerCurrentHp <= 0)
            {
                gameOverPopup.SetActive(true);
                if (Time.timeScale == 1)
                    Time.timeScale = 0;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                IsPause();

        }
        
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (gameExplainPopup.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    GameExplainPopup();
            }else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    GameEndPopup();
            }           

        }
        
    }

    public void IsPause()
    {
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;
            settingPopup.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            settingPopup.SetActive(true);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void AgainButton()
    {
        Time.timeScale = 1;
        GameManager.instance.Init();
        SceneManager.LoadScene("GameScene");        
    }

    public void GameEndPopup()
    {
        if (gameEndPopup.activeSelf)
            gameEndPopup.SetActive(false);
        else
            gameEndPopup.SetActive(true);
    }

    public void GameExplainPopup()
    {
        if (gameExplainPopup.activeSelf)
            gameExplainPopup.SetActive(false);
        else
            gameExplainPopup.SetActive(true);
    }
    

    public void GameEndButton()
    {
        Application.Quit();
    }

}
