using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Holder : MonoBehaviour
{

    public GameObject bomb; // bomb image holder 
    public void Hide()
    {
        GetComponent<BoxCollider2D>().enabled = false; // disable this collider 
        bomb.SetActive(false); // hide the bomb image
        Invoke("Reenable", 1.5f); // invote reenable after 1.5 seconds 

    }

    void Reenable()
    {
        GetComponent<BoxCollider2D>().enabled = true; // enable collider 
        bomb.SetActive(true); // display image
    }


}
