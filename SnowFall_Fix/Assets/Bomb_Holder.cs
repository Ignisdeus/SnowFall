using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Holder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bomb; 

    public void Hide()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        bomb.SetActive(false);
        Invoke("Reenable", 1.5f);

    }

    void Reenable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        bomb.SetActive(true);
    }


}
