using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Puck puck;
    public TextMeshProUGUI playerScoreUI;
    public TextMeshProUGUI computerScoreUI;
    public GameObject cameraObject;
    public float duration = 1f;
    public bool start = false;
    public AnimationCurve curve;

    private int playerScore;
    private int computerScore;

    private void Update()
    {
        CheckForWinner();
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    public void PlayerScores()
    {
        start = true;
        playerScore++;
        playerScoreUI.text = playerScore.ToString();
        this.puck.ResetPuck();
    }

    public void ComputerScore()
    {
        start = true;
        computerScore++;
        computerScoreUI.text = computerScore.ToString();
        this.puck.ResetPuck();
    }

    void CheckForWinner()
    {
        if (playerScore == 11)
        {
            Debug.Log("Player Wins");
        }
        else if (computerScore == 11)
        {
            Debug.Log("AI Wins");
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = cameraObject.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            cameraObject.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        cameraObject.transform.position = startPosition;
    }
}
