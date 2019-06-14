using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    private Image healthImage;

    void Awake()
    {
        if(tag == "Boss")
        {
            healthImage = GameObject.Find("Health Foreground Boss").GetComponent<Image>();
        }
        else
        {
            healthImage = GameObject.Find("Health Foreground").GetComponent<Image>();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthImage.fillAmount = health / 100f;

        if(health <= 0)
        {

        }
    }
}