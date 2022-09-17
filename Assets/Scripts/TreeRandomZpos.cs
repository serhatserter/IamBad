using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomZpos : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 temp = transform.GetChild(i).localPosition;
            temp.z = Random.Range(0, 0.5f);
            transform.GetChild(i).localPosition = temp;

        }
    }
}
