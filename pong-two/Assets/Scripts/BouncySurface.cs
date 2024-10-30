using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Puck puck = collision.gameObject.GetComponent<Puck>();

        if (puck != null )
        {
            Vector2 normal = collision.GetContact(0).normal;
            puck.AddForce(-normal * this.bounceStrength);
        }
    }
}
