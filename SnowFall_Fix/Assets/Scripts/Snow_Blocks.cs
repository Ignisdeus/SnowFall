using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow_Blocks : MonoBehaviour
{
    public Vector2[] dropPoints; // the range where the ice blocks can spawn 
    public GameObject iceBlock; // iceblock prefab
    void Start()
    {
        StartCoroutine(Spawn()); // at the start of the game begin the Coroutine
    }

    float delay = 2f; // delay between falling blocks 
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay); // wait untill th delay has elapsed 
        Instantiate(iceBlock, dropPoints[Random.Range(0, dropPoints.Length)], Quaternion.identity); // spawn in ice block 
        if(delay > 0.5f) // if the delay is > than 0.5
        {
            delay -= 0.05f; // reduce the delay time. 
        }
        StartCoroutine(Spawn()); // restart the coroutine


    }
}
