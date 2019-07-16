using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttack : MonoBehaviour
{
    public GameObject bossFire;
    public GameObject bossMagic;

    private Transform playerTarget;

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void BossFireTornado()
    {
        Instantiate(bossFire, playerTarget.position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }

    void BossSpell()
    {
        Vector3 temporary = playerTarget.position;
        temporary.y += 1.5f;
        Instantiate(bossMagic, temporary, Quaternion.identity);
    }
}