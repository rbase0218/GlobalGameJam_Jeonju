using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTests : MonoBehaviour
{
    public Animator animator;
    public string animationName;

    [ContextMenu("Test Animation")]
    public void PlayAnimation()
    {
        animator.SetTrigger(animationName);
    }
}
