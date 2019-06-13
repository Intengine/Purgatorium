using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private bool isShielded;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool Shielded
    {
        get
        { 
        return isShielded;
        }

        set
        {
        isShielded = value;
        }
    }

    public void TakeDamage(float amount)
    {
        if(!isShielded)
        {
            health -= amount;

            if(health <= 0f)
            {
                animator.SetBool("Death", true);

                if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
                {
                    // PLAYER DIED
                }
            }
        }
    }
}