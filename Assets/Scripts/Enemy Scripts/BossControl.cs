using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour
{
    private Transform playerTarget;
    private BossStateChecker bossStateChecker;
    private NavMeshAgent navAgent;
    private Animator animator;

    private bool finishedAttacking = true;
    private float currentAttackTime;
    private float waitAttackTime = 1f;

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        bossStateChecker = GetComponent<BossStateChecker>();
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(finishedAttacking)
        {
            GetStateControl();
        }
        else
        {
            animator.SetInteger("Atk", 0);

            if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttacking = true;
            }
        }
    }

    void GetStateControl()
    {
        if(bossStateChecker.BossState == BossState.DEATH)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject, 3f);
        }
        else
        {
            if(bossStateChecker.BossState == BossState.PAUSE)
            {
                navAgent.isStopped = false;
                animator.SetBool("Run", true);
                navAgent.SetDestination(playerTarget.position);
            } else if(bossStateChecker.BossState == BossState.ATTACK)
            {
                animator.SetBool("Run", false);

                Vector3 targetPosition = new Vector3(playerTarget.position.x, transform.position.y, playerTarget.position.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);
            }
        }
    }
}