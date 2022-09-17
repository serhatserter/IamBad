using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class FailPanelAnimations : MonoBehaviour
{
    public Image PanelImage;
    public  TMP_Text Text;
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        PanelImage.DOFade(1, 5f);
        Text.DOFade(1, 2f).OnComplete(() => {

            Button.SetActive(true);
        
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
