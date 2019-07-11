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
        
    }

    void Update()
    {
        
    }
}