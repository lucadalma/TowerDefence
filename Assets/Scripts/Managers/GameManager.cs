using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus 
{
    MainMenu,
    GameRunning,
    GameOver,
    PauseGame
}


public class GameManager : MonoBehaviour
{
    public GameStatus gameStatus;

    UIManager uIManager;

    void Start()
    {
        gameStatus = GameStatus.MainMenu;
        uIManager = FindAnyObjectByType<UIManager>();
    }

    void Update()
    {
        if (gameStatus == GameStatus.MainMenu)
        {
            Time.timeScale = 0;
            uIManager.MainMenu();
        } 
        else if (gameStatus == GameStatus.GameRunning)
        {
            Time.timeScale = 1;
            uIManager.InGame();
        }
        else if (gameStatus == GameStatus.PauseGame)
        {
            Time.timeScale = 0;
            uIManager.PauseGame();
        }
        else if (gameStatus == GameStatus.GameOver)
        {
            Time.timeScale = 0;
            uIManager.GameOver();
        }

        if (Input.GetKey(KeyCode.Escape) && gameStatus == GameStatus.GameRunning)
        {
            gameStatus = GameStatus.PauseGame;
        }
        else if (Input.GetKey(KeyCode.Escape) && gameStatus == GameStatus.PauseGame)
        {
            gameStatus = GameStatus.GameRunning;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        gameStatus = GameStatus.GameRunning;
    }

    public void PauseGame()
    {
        gameStatus = GameStatus.PauseGame;
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
