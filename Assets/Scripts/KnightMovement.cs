using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    CharacterController characterController;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 dir = (GameManager.Instance.Player.position - transform.position).normalized;
        characterController.Move(dir * 0.01f);

        SetLookDir();
    }

    void SetLookDir()
    {
        if (transform.position.x < GameManager.Instance.Player.position.x)
        {
            if (transform.localScale.x < 0)
            {
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
    }
}
