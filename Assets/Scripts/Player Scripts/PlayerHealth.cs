using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private bool isShielded;

    private Animator animator;

    private Image healthImage;

    void Awake()
    {
        animator = GetComponent<Animator>();
        healthImage = GameObject.Find("Health Icon").GetComponent<Image>();
    }

    public bool Shielded
    {
        get
        { 
        return isShielded;
        }

        set
        {
        isShielded = value;
        }
    }

    public void TakeDamage(float amount)
    {
        if(!isShielded)
        {
            health -= amount;
            healthImage.fillAmount = health / 100f;

            if(health <= 0f)
            {
                animator.SetBool("Death", true);

                if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
                {
                    // PLAYER DIED
                }
            }
        }
    }

    public void HealPlayer(float healAmount)
    {
        health += healAmount;

        if(health > 100f)
        {
            health = 100f;
        }
        healthImage.fillAmount = health / 100f;
    }
}