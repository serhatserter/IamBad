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

    public TMP_Text Name;
    public List<Image> Dialogs;
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

        Name.DOFade(0, 0.5f).OnComplete(() =>
        {
            Dialogs[0].DOFade(1, 0.5f).SetDelay(0.5f).OnComplete(() =>
            {
                Dialogs[0].DOFade(0, 0.5f).SetDelay(3f).OnComplete(() =>
                {
                    Dialogs[1].DOFade(1, 0.5f).SetDelay(0.5f).OnComplete(() =>
                    {
                        Dialogs[1].DOFade(0, 0.5f).SetDelay(5f).OnComplete(() =>
                        {
                            Dialogs[2].DOFade(1, 0.5f).SetDelay(0.5f).OnComplete(() =>
                            {
                                Dialogs[2].DOFade(0, 0.5f).SetDelay(5f).OnComplete(() =>
                                {
                                    Dialogs[3].DOFade(1, 0.5f).SetDelay(0.5f).OnComplete(() =>
                                    {
                                        Dialogs[3].DOFade(0, 0.5f).SetDelay(5f).OnComplete(() =>
                                        {
                                            Dialogs[4].DOFade(1, 0.5f).SetDelay(0.5f).OnComplete(() =>
                                            {
                                                Dialogs[4].DOFade(0, 0.5f).SetDelay(5f).OnComplete(() =>
                                                {
                                                    Dialogs[5].DOFade(1, 0.5f).SetDelay(0.5f).OnComplete(() =>
                                                    {
                                                        Dialogs[5].DOFade(0, 0.5f).SetDelay(5f).OnComplete(() =>
                                                        {
                                                            OnDarkScreen();

                                                        });

                                                    });

                                                });

                                            });

                                        });

                                    });

                                });

                            });

                        });

                    });

                });

            });

        });
    }


    public void OnDarkScreen()
    {

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
