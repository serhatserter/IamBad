using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : MonoBehaviour
{
    public GameObject Knight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateKnight());
    }

    float time = 1f;
    IEnumerator CreateKnight()
    {
        while (true)
        {
            time = Random.Range(1f, 2f);
            yield return new WaitForSeconds(time);

            if (GameManager.Instance.KnightCreateCount < 50)
            {
                GameObject newKnight = Instantiate(Knight);
                newKnight.transform.position = transform.position;

                GameManager.Instance.KnightCreateCount++;

            }
        }
    }
}
