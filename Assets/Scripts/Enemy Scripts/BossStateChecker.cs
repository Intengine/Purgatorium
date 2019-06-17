using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    NONE,
    IDLE,
    PAUSE,
    ATTACK,
    DEATH
}

public class BossStateChecker : MonoBehaviour
{
    private Transform playerTarget;
    private BossState bossState = BossState.NONE;
    private float distanceToTarget;
    private EnemyHealth bossHealth;

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        bossHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        
    }
}