using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : MonoBehaviour
{
    public GameObject Knight;
    bool isEnd;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Win += OnGameEnd;
        GameManager.Instance.Fail += OnGameEnd;

        StartCoroutine(CreateKnight());
    }

    private void OnDestroy()
    {
        GameManager.Instance.Win -= OnGameEnd;
        GameManager.Instance.Fail -= OnGameEnd;
    }

    private void OnGameEnd()
    {
        isEnd = true;
    }

    float time = 1f;
    int random;
    IEnumerator CreateKnight()
    {
        while (!isEnd)
        {
            time = Random.Range(1f, 2f);
            yield return new WaitForSeconds(time);
            random = Random.Range(1, 10);

            if (GameManager.Instance.KnightCreateCount < 50 && random < 3)
            {
                GameObject newKnight = Instantiate(Knight);
                newKnight.transform.position = transform.position;

                GameManager.Instance.KnightCreateCount++;

            }
        }
    }
}
