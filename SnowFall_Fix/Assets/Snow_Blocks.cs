using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow_Blocks : MonoBehaviour
{
    public Vector2[] dropPoints;
    public GameObject iceBlock;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    float delay = 2f;
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(iceBlock, dropPoints[Random.Range(0, dropPoints.Length)], Quaternion.identity);
        if(delay > 0.5f)
        {
            delay -= 0.05f;
        }
        StartCoroutine(Spawn());


    }
}
