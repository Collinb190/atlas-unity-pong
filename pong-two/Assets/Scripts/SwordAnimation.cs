using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    public Animator animator;
    public bool ready = true;

    private void Update()
    {
        CheckAnimations();
    }

    void CheckAnimations()
    {
        if (Input.GetKeyDown(KeyCode.D) && ready)
        {
            ready = false;
            animator.SetBool("isIdle", false);
            animator.SetTrigger("isParrying");
            StartCoroutine(ResetParry());
        }
    }

    void OnAnimationComplete()
    {
        animator.SetBool("isIdle", true);
    }

    IEnumerator ResetParry()
    {
        yield return new WaitForSeconds(1);
        ready = true;
    }
}
