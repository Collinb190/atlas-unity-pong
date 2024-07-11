using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnePlayerGame()
    {
        string onePlayerGame = "Game";
        SceneManager.LoadScene(onePlayerGame);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
