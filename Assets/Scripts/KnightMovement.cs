using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public ParticleSystem HitParticle;

    CharacterController characterController;
    float Speed;
    bool isStart;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        Speed = Random.Range(0.002f, 0.010f);
        characterController = GetComponent<CharacterController>();

        Invoke("StartMovement", 0.2f);
    }

    void StartMovement()
    {
        isStart = true;
    }

    void Update()
    {
        if (isStart)
        {
            Vector3 dir = (GameManager.Instance.Player.position - transform.position).normalized;
            characterController.Move(dir * Speed);

            SetLookDir();

        }
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

    public void Death()
    {
        characterController.enabled = false;
        isStart = false;
        animator.enabled = false;

        HitParticle.Play();

        for (int i = 0; i < transform.childCount-1; i++)
        {
            Rigidbody rb = transform.GetChild(i).GetComponent<Rigidbody>();

            rb.isKinematic = false;

            rb.AddForce(Vector3.up * 150f);
            rb.AddExplosionForce(25f, (transform.position + Vector3.up), 3f);

            StartCoroutine(DeathDestroy());
        }


    }

    IEnumerator DeathDestroy()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }
}
