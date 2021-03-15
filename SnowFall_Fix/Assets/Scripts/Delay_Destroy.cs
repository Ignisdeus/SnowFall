using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay_Destroy : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5f); // destory this object after 5 seconds
    }
}
