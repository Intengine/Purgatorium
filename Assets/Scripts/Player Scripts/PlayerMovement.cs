using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Animator playerAnimator;
    private CharacterController playerController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private Vector3 targetPosition = Vector3.zero;
    private Vector3 playerMove = Vector3.zero;

    private float moveSpeed = 5f;
    private float gravity = 9.8f;
    private float height;
    private float playerToPointDistance;
    private bool canMove;
    private bool finishedMovement = true;

	void Awake () {
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
	}

	void Update () {
        MoveThePlayer();
        playerController.Move(playerMove);
	}

    void MoveThePlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    playerToPointDistance = Vector3.Distance(transform.position, hit.point);

                    if(playerToPointDistance >= 1.0f)
                    {
                        canMove = true;
                        targetPosition = hit.point;
                    }
                }
            }
        }
        if (canMove)
        {
            playerAnimator.SetFloat("Walk", 1.0f);

            Vector3 targetTemporary = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetTemporary - transform.position),
                15.0f * Time.deltaTime);

            playerMove = transform.forward * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPosition) <= 0.5f)
            {
                canMove = false;
            }
        }
        else
        {
            playerMove.Set(0f, 0f, 0f);
            playerAnimator.SetFloat("Walk", 0f);
        }
    }
}