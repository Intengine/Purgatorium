using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;

    private Transform playerTarget;
    private Animator animator;
    private bool finishedAttack = true;
    private float damageDistance = 2f;

    private PlayerHealth playerHealth;

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        playerHealth = playerTarget.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if(finishedAttack)
        {
            DealDamage(CheckIfAttacking());
        }
        else
        {
            if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttack = true;
            }
        }
    }

    bool CheckIfAttacking()
    {
        bool isAttacking = false;

        if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Atk1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Atk2"))
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                isAttacking = true;
                finishedAttack = false;
            }
        }

        return isAttacking;
    }

    void DealDamage(bool isAttacking)
    {
        if(isAttacking)
        {
            if(Vector3.Distance(transform.position, playerTarget.position) <= damageDistance)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}