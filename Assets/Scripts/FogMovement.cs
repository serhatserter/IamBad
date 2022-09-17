using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FogMovement : MonoBehaviour
{

    void Start()
    {
        float moveY = Random.Range(-3f, 3f);
        float time = Random.Range(4f, 6f);

        transform.DOMoveY(transform.position.y + moveY, time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
