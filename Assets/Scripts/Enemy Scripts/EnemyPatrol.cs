using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] walkPoints;
    private int walkIndex = 0;

    private Transform playerTarget;
    private Animator animator;
    private NavMeshAgent navAgent;

    private float walkDistance = 8f;
    private float attackDistance = 2f;

    private float currentAttackTime;
    private float waitAttackTime = 1f;

    private Vector3 nextDestination;

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTarget.position);

        if(distance > walkDistance)
        {
            if(navAgent.remainingDistance <= 0.5f)
            {
                navAgent.isStopped = false;
                animator.SetBool("Walk", true);
                animator.SetBool("Run", false);
                animator.SetInteger("Atk", 0);

                nextDestination = walkPoints[walkIndex].position;
                navAgent.SetDestination(nextDestination);

                if(walkIndex == walkPoints.Length - 1)
                {
                    walkIndex = 0;
                }
                else
                {
                    walkIndex++;
                }
            }
        }
    }
}