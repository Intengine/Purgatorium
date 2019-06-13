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

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(finishedAttack)
        {
            // deal damage
        }
        else
        {
            if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttack = true;
            }
        }
    }

    void DealDamage()
    {

    }
}