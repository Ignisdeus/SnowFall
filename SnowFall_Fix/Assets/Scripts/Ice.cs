using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject iceImage; // image for ice
    AudioSource audioS; // audio source refrence 
    public BoxCollider2D myBox; // this objects box collider
    private void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>(); // create and add an audioSource to this object and the refrence
        Invoke("NameChange", 1f); // change my tag after 1 second
    }

    void NameChange() 
    {
        tag = "GameOver"; // my tag is now game over 
    }
    float integrity = 1f; // value to use on alpha. 
    public AudioClip hit; // audio clip for when the ice hits the ground 
    private void OnTriggerStay2D(Collider2D other) // while this object is in a collider 
    {
        if(other.gameObject.tag == "Dropped_Bomb") { // if the other collider is tagged "Dropped_Bomb"
            iceImage.GetComponent<SpriteRenderer>().color = new Color(255,255,255,integrity); // change the alpha value of the sprite renderer
            integrity -= 0.5f * Time.deltaTime; // integrity degenarates by 0.5f and a scaler (in this case time). 

            if(integrity <= 0f) // if the integrity of the ice is 0 
            {
                Destroy(this.gameObject); // destory the ice
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) // if i collide with an object 
    {
        Debug.Log(other.gameObject.tag); 
        Destroy(myBox); // destory my collider 
        if(other.gameObject.tag != "GameOver") // if the other game object is not tagged "GameOver"  
        {
            audioS.PlayOneShot(hit, 0.7f); // play this hit audio clip 
        }
    }
}
