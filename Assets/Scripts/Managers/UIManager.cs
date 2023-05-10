using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject MainMenuCanvas;

    [SerializeField]
    public GameObject PauseGameCanvas;

    [SerializeField]
    public GameObject GameOverCanvas;

    [SerializeField]
    public GameObject InGameCanvas;

    public void MainMenu() 
    {
        MainMenuCanvas.SetActive(true);
        PauseGameCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        InGameCanvas.SetActive(false);
    }

    public void PauseGame()
    {
        MainMenuCanvas.SetActive(false);
        PauseGameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        InGameCanvas.SetActive(false);
    }

    public void GameOver()
    {
        MainMenuCanvas.SetActive(false);
        PauseGameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
        InGameCanvas.SetActive(false);
    }

    public void InGame()
    {
        MainMenuCanvas.SetActive(false);
        PauseGameCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
    }

}
