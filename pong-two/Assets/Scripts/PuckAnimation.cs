using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckAnimation : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Puck puck = collision.gameObject.GetComponent<Puck>();

        if (puck != null)
        {
            animator.SetBool("isIdle", false);
            animator.SetTrigger("Blink");
            StartCoroutine(ResetIdle());
        }
    }

    IEnumerator ResetIdle()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isIdle", true);
    }
}
