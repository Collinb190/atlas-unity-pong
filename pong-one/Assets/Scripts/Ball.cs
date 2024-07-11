using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 600f;
    public float increaseSpeed = 25f;
    public float topSpeed = 1200f;

    private Rigidbody2D rb;
    private Vector2 startingLaunch;
    private Vector2 startingPoint;
    private GameManager gameManager;
    public AudioSource ballSound;
    public AudioSource goalSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        startingPoint = rb.position;
        Launch();
    }

    void Launch()
    {
        float randomDirectionY = Random.Range(-1, 2);
        float randomDirectionX = Random.Range(0, 2) * 2 - 1;
        startingLaunch = new Vector2(randomDirectionX, randomDirectionY).normalized;
        rb.velocity = startingLaunch * startSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            Debug.Log("hit paddle");
            Debug.Log(rb.velocity.magnitude);
            ballSound.Play();
            Vector2 sendBack = new Vector2(-rb.velocity.x, Random.Range(-300, 301)).normalized;
            if (rb.velocity.magnitude < topSpeed)
            {
                rb.velocity = sendBack * (rb.velocity.magnitude + increaseSpeed);
            }
            else
            {
                rb.velocity = sendBack * topSpeed;
            }
        }
        else if (collision.CompareTag("Boundry"))
        {
            Debug.Log("hit boundry");
            Debug.Log(rb.velocity.magnitude);
            ballSound.Play();
            Vector2 sendBack = new Vector2(rb.velocity.x, -rb.velocity.y).normalized;
            if (rb.velocity.magnitude < topSpeed)
            {
                rb.velocity = sendBack * (rb.velocity.magnitude + increaseSpeed);
            }
            else
            {
                rb.velocity = sendBack * topSpeed;
            }
        }
        else if (collision.CompareTag("Goal"))
        {
            Debug.Log("goal scored");
            Debug.Log(rb.velocity.magnitude);
            goalSound.Play();
            if (collision.name == "LeftGoal")
            {
                // Right player scores
                gameManager.AddScore("Right");
            }
            else
            {
                // Left player scores
                gameManager.AddScore("Left");
            }
            Reset();
        }
    }

    void Reset()
    {
        rb.position = startingPoint;
        startSpeed = 600f;
        Launch();
    }
}
