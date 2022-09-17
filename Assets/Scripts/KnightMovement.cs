using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public ParticleSystem HitParticle;
    public ParticleSystem CollectParticle;

    CharacterController characterController;
    float Speed;
    bool isStart;
    bool isDeath;
    Animator animator;

    void Start()
    {
        GameManager.Instance.Win += OnGameEnd;
        GameManager.Instance.Fail += OnGameEnd;


        animator = GetComponent<Animator>();

        Speed = Random.Range(0.002f, 0.010f);
        characterController = GetComponent<CharacterController>();

        Invoke("StartMovement", 0.2f);
    }

    private void OnDestroy()
    {
        GameManager.Instance.Win -= OnGameEnd;
        GameManager.Instance.Fail -= OnGameEnd;
    }

    private void OnGameEnd()
    {
        isStart = false;
        animator.SetBool("IsWalk", false);
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
            if (characterController != null) characterController.Move(dir * Speed);

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
        if (!isDeath)
        {
            isDeath = true;

            GameManager.Instance.BarCount -= 0.02f;

            GetComponent<Collider>().enabled = false;

            Destroy(characterController);
            //characterController.enabled = false;

            isStart = false;
            animator.enabled = false;

            HitParticle.Play();

            for (int i = 0; i < transform.childCount - 2; i++)
            {
                Rigidbody rb = transform.GetChild(i).GetComponent<Rigidbody>();

                rb.isKinematic = false;

                rb.AddForce(Vector3.up * 150f);
                rb.AddExplosionForce(25f, (transform.position + Vector3.up), 3f);

                StartCoroutine(DeathDestroy());
            }

        }


    }

    IEnumerator DeathDestroy()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && !isDeath && isStart)
        {
            GameManager.Instance.Collect?.Invoke();

            GameManager.Instance.BarCount += 0.02f;

            characterController.enabled = false;
            isStart = false;
            animator.enabled = false;

            CollectParticle.Play();
            CollectParticle.transform.parent = null;

            Destroy(gameObject);
        }
    }
}
