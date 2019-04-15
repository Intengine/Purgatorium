using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Image fillWaitImage1;
    public Image fillWaitImage2;
    public Image fillWaitImage3;
    public Image fillWaitImage4;
    public Image fillWaitImage5;
    public Image fillWaitImage6;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };

    private Animator animator;
    private bool canAttack = true;
    private PlayerMovement playerMove;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        CheckToFade();
        CheckInput();
    }

    void CheckInput()
    {
        if(animator.GetInteger("Atk") == 0)
        {

        }
    }
}