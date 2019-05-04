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
        
    }

    void Update()
    {
        
    }
}