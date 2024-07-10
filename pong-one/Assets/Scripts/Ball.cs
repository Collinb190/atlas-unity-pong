using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 400f;
    public float increaseSpeed = 100f;
    public float topSpeed = 600f;

    private Rigidbody2D rb;
    private Vector2 startingLaunch;
    private Vector2 startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPoint = rb.position;
        Launch();
    }

    void Launch()
    {
        float randomDirectionY = Random.Range(-1, 2);
        float randomDirectionX = Random.Range(0, 2) * 2 - 1;
        startingLaunch = new Vector2(-1, randomDirectionY).normalized;
        rb.velocity = startingLaunch * startSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Increase ball speed
        if (rb.velocity.magnitude < topSpeed)
        {
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + increaseSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            Debug.Log("hit paddle");
            Debug.Log(rb.velocity.magnitude);
            Vector2 sendBack = new Vector2(-rb.velocity.x, Random.Range(-90, 91)).normalized;
            rb.velocity = sendBack * rb.velocity.magnitude;
        }
        else if (collision.CompareTag("Boundry"))
        {
            Debug.Log("hit boundry");
            Debug.Log(rb.velocity.magnitude);
            Vector2 sendBack = new Vector2(rb.velocity.x, -rb.velocity.y).normalized;
            rb.velocity = sendBack * rb.velocity.magnitude;
        }
        else if (collision.CompareTag("Goal"))
        {
            Debug.Log("goal scored");
            Debug.Log(rb.velocity.magnitude);
            Reset();
        }
    }

    void Reset()
    {
        rb.position = startingPoint;
        startSpeed = 350f;
        Launch();
    }
}

