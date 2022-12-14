using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class WinFailController : MonoBehaviour
{
    public GameObject FailPanel;
    public GameObject WinPanel;
    public List<ParticleSystem> HitParticles;
    public Image StartPanel;

    public AudioSource Music;
    public AudioSource WinSound;
    public AudioSource FailSound;
    // Start is called before the first frame update
    void Start()
    {
        StartPanel.DOFade(0, 1f);
    }

    bool isEnd;
    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            if (GameManager.Instance.BarCount < 0.3f)
            {
                Music.Stop();
                FailSound.Play();

                isEnd = true;
                CloseParticles();
                GameManager.Instance.Fail?.Invoke();
                FailPanel.SetActive(true);
            }

            if (GameManager.Instance.BarCount > 0.98f)
            {
                Music.Stop();
                WinSound.Play();

                isEnd = true;
                CloseParticles();
                GameManager.Instance.Win?.Invoke();
                WinPanel.SetActive(true);
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

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
