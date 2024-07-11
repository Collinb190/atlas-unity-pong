using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 11;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    //public TextMeshProUGUI resultText;

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
        //resultText.text = result;
        Time.timeScale = 0; // Stop the game
        // Show restart or quit options (optional)
    }
}
