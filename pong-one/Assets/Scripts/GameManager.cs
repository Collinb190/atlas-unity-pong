using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 11;
    public bool isPaused = false;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI playerOneWin;
    public TextMeshProUGUI playerOneLost;
    public TextMeshProUGUI playerTwoWin;
    public TextMeshProUGUI playerTwoLost;
    public GameObject endMenu;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Activate the pause menu
        endMenu.gameObject.SetActive(true);

    }

    public void Resume()
    {
        // Resume the game
        Time.timeScale = 1f;
        isPaused = false;

        // Deactivate the pause menu
        endMenu.gameObject.SetActive(false);
    }

    public void AddScore(string player)
    {
        if (player == "Left")
        {
            leftScore++;
            if (leftScore >= winningScore)
            {
                EndGame("Player One Wins!");
            }
        }
        else if (player == "Right")
        {
            rightScore++;
            if (rightScore >= winningScore)
            {
                EndGame("Player Two Wins!");
            }
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    void EndGame(string result)
    {
        Time.timeScale = 0; // Stop the game

        if (result == "Player One Wins!")
        {
            Debug.Log("Player One Wins!");
            playerOneWin.gameObject.SetActive(true);
            playerTwoLost.gameObject.SetActive(true);
            endMenu.gameObject.SetActive(true);
        }
        else if (result == "Player Two Wins!")
        {
            Debug.Log("Player Two Wins!");
            playerOneLost.gameObject.SetActive(true);
            playerTwoWin.gameObject.SetActive(true);
            endMenu.gameObject.SetActive(true);
        }
    }

    public void Replay()
    {
        // Reload the current scene
        Time.timeScale = 1f; // Ensure the game is not paused
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Method to handle exiting the game
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
