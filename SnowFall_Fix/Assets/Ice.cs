using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject iceImage;
    AudioSource audioS;
    public BoxCollider2D myBox; 
    private void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>();
        Invoke("NameChange", 1f);
    }

    void NameChange()
    {
        tag = "GameOver";
    }
    float integrity = 1f;
    public AudioClip hit; 
    private void OnTriggerStay2D(Collider2D other)
    {
       
        if(other.gameObject.tag == "Dropped_Bomb") {
            iceImage.GetComponent<SpriteRenderer>().color = new Color(255,255,255,integrity); 
            integrity -= 0.5f * Time.deltaTime;

            if(integrity <= 0f)
            {
                Destroy(this.gameObject); 
            }

        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        Debug.Log(other.gameObject.tag);
        Destroy(myBox);
        if(other.gameObject.tag != "GameOver")
        {

            audioS.PlayOneShot(hit, 0.7f);
        }
    }
}
