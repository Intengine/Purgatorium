using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnEnable()
    {
        playerHealth.Shielded = true;
        print("Player is shielded!");
    }

    void OnDisable()
    {
        playerHealth.Shielded = false;
        print("Player is NOT shielded!");
    }
}