using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D puck;

    void FixedUpdate()
    {
        BallTrack();
    }

    void BallTrack()
    {
        if (this.puck.velocity.x > 0f)
        {
            if (this.puck.position.y > this.transform.position.y)
            {
                rb.AddForce(Vector2.up * this.paddleSpeed);
            }
            else if (this.puck.position.y < this.transform.position.y)
            {
                rb.AddForce(Vector2.down * this.paddleSpeed);
            }
        }
        else
        {
            if (this.transform.position.y > 0f)
            {
                rb.AddForce(Vector2.down * this.paddleSpeed);
            }
            else if (this.transform.position.y < 0f)
            {
                rb.AddForce(Vector2.up * this.paddleSpeed);
            }
        }
    }
}
