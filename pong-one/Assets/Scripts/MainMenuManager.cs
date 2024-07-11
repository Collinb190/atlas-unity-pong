using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void TwoPlayerGame()
    {
        string twoPlayerGame = "Game";
        SceneManager.LoadScene(twoPlayerGame);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
