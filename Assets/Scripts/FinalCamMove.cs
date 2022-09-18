using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalCamMove : MonoBehaviour
{
    public Image Panel;
    public TMP_Text EndText;
    void Start()
    {
        Panel.DOFade(0, 1).SetDelay(1f);


        Vector3 target = new Vector3(0, 0.8f, 0.6f);
        transform.DOMove(target, 10f).SetEase(Ease.InOutSine).SetDelay(5f).OnComplete(() =>
        {
            Panel.DOFade(1, 3).SetDelay(1f).OnComplete(() =>
            {

                EndText.DOFade(1, 1).OnComplete(() =>
                {
                    Invoke("ChangeScene", 5f);
                });
            });



        });
    }


    void ChangeScene()
    {
        SceneManager.LoadScene(0);

    }
}
