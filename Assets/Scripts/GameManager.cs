using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public Transform Player;

    public int KnightCreateCount;

    public float BarCount;


    public Action Collect;
    public Action Win;
    public Action Fail;

    private void Start()
    {
        BarCount = 0.5f;
    }
}
