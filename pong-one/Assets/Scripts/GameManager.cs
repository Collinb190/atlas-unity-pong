using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 11;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI playerOneWin;
    public TextMeshProUGUI playerOneLost;
    public TextMeshProUGUI playerTwoWin;
    public TextMeshProUGUI playerTwoLost;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateScoreUI();
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
        }
        else if (result == "Player Two Wins!")
        {
            Debug.Log("Player Two Wins!");
            playerOneLost.gameObject.SetActive(true);
            playerTwoWin.gameObject.SetActive(true);
        }
    }
}
