using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanelAnimations : MonoBehaviour
{
    public Image PanelImage;

    // Start is called before the first frame update
    void Start()
    {
        PanelImage.DOFade(1, 3f).SetEase(Ease.Linear).SetDelay(2f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        });

    }
}
