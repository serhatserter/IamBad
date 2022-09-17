using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFillMovement : MonoBehaviour
{
    public Image BarFillImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BarFillImage.fillAmount = Mathf.MoveTowards(BarFillImage.fillAmount, GameManager.Instance.BarCount, Time.deltaTime * 0.5f);
    }
}
