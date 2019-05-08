using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public enum EnemyState
{
    IDLE,
    WALK,
    RUN,
    PAUSE,
    GOBACK,
    ATTACK,
    DEATH
}

public class EnemyControl : MonoBehaviour
{
    private float attackDistance = 1.5f;
    private float alertAttackDistance = 8f;
    private float followDistance = 15f;
    private float enemyToPlayerDistance;

    private float moveSpeed = 2f; // faster
    private float walkSpeed = 1f; // slower

    private float currentAttackTime;
    private float waitAttackTime = 1f;

    [HideInInspector]
    public EnemyState enemyCurrentState = EnemyState.IDLE;
    private EnemyState enemyLastState = EnemyState.IDLE;

    private Transform playerTarget;
    private Vector3 initialPosition;
    private Vector3 whereToMove = Vector3.zero;

    private CharacterController characterController;

    private Animator animator;
    private bool finishedAnimation = true;
    private bool finishedMovement = true;

    private NavMeshAgent navAgent;
    private Vector3 whereToNavigate;

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        initialPosition = transform.position;
        whereToNavigate = transform.position;
    }

    void Update()
    {
        if(enemyCurrentState != EnemyState.DEATH)
        {
            enemyCurrentState = SetEnemyState(enemyCurrentState, enemyLastState, enemyToPlayerDistance);
            if(finishedMovement)
            {
               // GetStateControl(enemyCurrentState);
            }
            else
            {
                if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    finishedMovement = true;
                } else if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsTag("Atk1") || animator.GetCurrentAnimatorStateInfo(0).IsTag("Atk2"))
                {
                    animator.SetInteger("Atk", 0);
                }
            }
        }
        else
        {
            animator.SetBool("Death", true);
            characterController.enabled = false;
            navAgent.enabled = false;

            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
            {
                Destroy(gameObject, 2f);
            }
        }
    }

    EnemyState SetEnemyState(EnemyState currentState, EnemyState lastState, float enemyToPlayerDistance)
    {
        enemyToPlayerDistance = Vector3.Distance(transform.position, playerTarget.position);
        float initialDistance = Vector3.Distance(initialPosition, transform.position);

        if(initialDistance > followDistance)
        {
            lastState = currentState;
            currentState = EnemyState.GOBACK;
        } else if(enemyToPlayerDistance <= attackDistance)
        {
            lastState = currentState;
            currentState = EnemyState.ATTACK;
        }
    }
}