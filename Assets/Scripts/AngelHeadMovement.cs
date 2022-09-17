using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class AngelHeadMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Collect += OnCollect;
        GameManager.Instance.Win += OnWin;
    }

    private void OnDestroy()
    {
        GameManager.Instance.Collect -= OnCollect;
        GameManager.Instance.Win -= OnWin;

    }

    private void OnWin()
    {
        Camera.main.transform.DOShakePosition(1f, 0.2f, 5, 10, false, true);
        transform.parent.GetComponent<Animator>().enabled = false;

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Rigidbody temp = transform.parent.GetChild(i).GetComponent<Rigidbody>();

            temp.isKinematic = false;
            temp.AddForce(Vector3.up * 300f);
            temp.AddTorque(Vector3.forward * 250f);
        }

    }

    bool isShake;
    void OnCollect()
    {
        if (!isShake)
        {
            isShake = true;

            transform.DOShakePosition(1.5f, 0.2f, 10, 10, false, true).OnComplete(() =>
            {
                isShake = false;

            });
        }
    }
}
