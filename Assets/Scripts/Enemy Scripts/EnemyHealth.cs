using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public Image healthImage;

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthImage.fillAmount = health / 100f;

        if(health <= 0)
        {

        }
    }
}