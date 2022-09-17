using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProgressController : MonoBehaviour
{
    public ParticleSystem Level2Particle, Level3Particle;
    public Transform Level4Parent;

    Tween rotateTween;
    bool isTween;
    void Update()
    {
        if (GameManager.Instance.BarCount >= 0.65f && GameManager.Instance.BarCount < 0.8f)
        {
            if (!Level2Particle.isPlaying) Level2Particle.Play();
        }
        else if (GameManager.Instance.BarCount >= 0.8f && GameManager.Instance.BarCount < 0.9f)
        {
            if (!Level3Particle.isPlaying) Level3Particle.Play();
        }
        else if (GameManager.Instance.BarCount >= 0.9f && GameManager.Instance.BarCount < 0.98f)
        {

            if (!isTween)
            {
                isTween = true;
                Level4Parent.DORotate(Level4Parent.eulerAngles + (Vector3.up * 3), 0.25f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);

            }
        }
    }
}
