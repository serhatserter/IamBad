using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform playerParent;
    SpriteRenderer playerSprite;
    Animator playerAnimator;
    CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerParent = transform.parent;
        playerController = playerParent.GetComponent<CharacterController>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookSpriteControl();
        SetAnimation();
        PlayerMove();
    }



    void LookSpriteControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerSprite.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerSprite.flipX = false;

        }
    }

    void SetAnimation()
    {
        if (Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("IsWalk", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalk", false);

        }
    }


    void PlayerMove()
    {
        //Vector3 newPos = Vector3.Lerp(playerParent.position, playerParent.position + PlayerMoveDir(), Time.deltaTime * 3f);

        playerController.Move(PlayerMoveDir() * 0.015f);
    }

    Vector3 PlayerMoveDir()
    {
        Vector3 zTemp, xTemp;
        if (Input.GetKey(KeyCode.W))
        {
            zTemp = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zTemp = Vector3.forward * -1;
        }
        else
        {
            zTemp = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xTemp = Vector3.right * -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xTemp = Vector3.right;
        }
        else
        {
            xTemp = Vector3.zero;
        }

        return (zTemp + xTemp).normalized;
    }

    /*
     *         if (Input.GetKeyDown(KeyCode.W))
        {

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerSprite.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerSprite.flipX = false;

        }
     * */
}
