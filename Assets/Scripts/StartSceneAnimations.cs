using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneAnimations : MonoBehaviour
{
    public Image Panel;

    public TMP_Text Text1, Text2;
    public Button Button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartPlay()
    {
        Button.gameObject.SetActive(false);

        Panel.DOFade(1, 1f).OnComplete(() =>
        {
            Text1.DOFade(1, 1f).SetDelay(1f).OnComplete(() =>
            {
                Text1.DOFade(0, 1f).SetDelay(5f).OnComplete(() =>
                {

                    Text2.DOFade(1, 1f).SetDelay(0.5f).OnComplete(() =>
                    {
                        Text2.DOFade(0, 1f).SetDelay(5f).OnComplete(() =>
                        {

                            SceneManager.LoadScene(1);

                        });

                    });

                });
            });
        });
    }
}
