using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Action die;

    public void Walk(bool isWalking)
    {
        animator.SetBool("Walk", isWalking);
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        die?.Invoke();
    }
}
