using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFailController : MonoBehaviour
{
    public List<ParticleSystem> HitParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    bool isEnd;
    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            if (GameManager.Instance.BarCount < 0.3f)
            {
                isEnd = true;
                CloseParticles();
                GameManager.Instance.Fail?.Invoke();
            }

            if (GameManager.Instance.BarCount > 0.98f)
            {
                isEnd = true;
                CloseParticles();
                GameManager.Instance.Win?.Invoke();
            }

        }
    }

    void CloseParticles()
    {
        for (int i = 0; i < HitParticles.Count; i++)
        {
            HitParticles[i].Stop();
        }
    }
}
