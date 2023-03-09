using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator runnerAnimator;

    private void Start()
    {
        runnerAnimator= GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            if (runnerAnimator != null)
            {
                runnerAnimator.SetTrigger("Idle");
            }
            else
            {
                runnerAnimator.SetTrigger("Run");

            }
        }
    }
}
