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

    private readonly int[] fadeImages = { 0, 0, 0, 0, 0, 0 };

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
            playerMove.FinishedMovement = false;

            if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovement = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerMove.TargetPosition = transform.position;

            if(playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                animator.SetInteger("Atk", 1);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                animator.SetInteger("Atk", 2);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;
                animator.SetInteger("Atk", 3);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[3] != 1 && canAttack)
            {
                fadeImages[3] = 1;
                animator.SetInteger("Atk", 4);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[4] != 1 && canAttack)
            {
                fadeImages[4] = 1;
                animator.SetInteger("Atk", 5);
            }
        } else if(Input.GetMouseButtonDown(1))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[5] != 1 && canAttack)
            {
                fadeImages[5] = 1;
                animator.SetInteger("Atk", 6);
            }
        }
        else
        {
            animator.SetInteger("Atk", 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPosition = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position),
                15f * Time.deltaTime);
        }
    }

    void CheckToFade()
    {
        if(fadeImages[0] == 1)
        {
            if(FadeAndWait(fillWaitImage1, 1.0f))
            {
                fadeImages[0] = 0;
            }
        } else if(fadeImages[1] == 1)
        {
            if (FadeAndWait(fillWaitImage2, 0.7f))
            {
                fadeImages[1] = 0;
            }
        } else if (fadeImages[2] == 1)
        {
            if (FadeAndWait(fillWaitImage3, 0.1f))
            {
                fadeImages[2] = 0;
            }
        } else if (fadeImages[3] == 1)
        {
            if (FadeAndWait(fillWaitImage4, 0.2f))
            {
                fadeImages[3] = 0;
            }
        } else if (fadeImages[4] == 1)
        {
            if (FadeAndWait(fillWaitImage5, 0.3f))
            {
                fadeImages[4] = 0;
            }
        } else if (fadeImages[5] == 1)
        {
            if (FadeAndWait(fillWaitImage5, 0.08f))
            {
                fadeImages[5] = 0;
            }
        }
    }

    bool FadeAndWait(Image fadeImage, float fadeTime)
    {
        bool faded = false;

        if(fadeImage == null)
        {
            return faded;
        }

        if(!fadeImage.gameObject.activeInHierarchy)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.fillAmount = 1f;
        }

        fadeImage.fillAmount -= fadeTime * Time.deltaTime;

        if(fadeImage.fillAmount <= 0.0f)
        {
            fadeImage.gameObject.SetActive(false);
            faded = true;
        }

        return faded;
    }
}