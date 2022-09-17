using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHit : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Knight")
        {
            GameManager.Instance.KnightCreateCount--;
            other.transform.GetComponent<KnightMovement>().Death();



            //Destroy(other.gameObject);
        }
    }
}
