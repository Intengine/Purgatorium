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
        SetState();
    }

    void SetState()
    {
        distanceToTarget = Vector3.Distance(transform.position, playerTarget.position);

        if(bossState != BossState.DEATH)
        {
            if(distanceToTarget > 3f && distanceToTarget <= 15f)
            {
                bossState = BossState.PAUSE;
            } else if(distanceToTarget > 15f)
            {
                bossState = BossState.IDLE;
            } else if(distanceToTarget <= 3f)
            {
                bossState = BossState.ATTACK;
            }
            else
            {
                bossState = BossState.NONE;
            }

            if(bossHealth.health <= 0f)
            {
                bossState = BossState.DEATH;
            }
        }
    }
    public BossState BossState
    {
        get { return bossState; }
        set { bossState = value; }
    }
}