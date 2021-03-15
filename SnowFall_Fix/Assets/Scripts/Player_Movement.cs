using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Vector3 startingPos;
    public Vector2 limits; 
    void Start()
    {
        startingPos = transform.position; // store starting posision. 
    }
    public bool isGrounded = true; // will check if the player is grounded.
    public bool isHolding = false; // will check if the player is holding the Bomb.
    public float speed = 10.0f; // default speed without an object. 
    public float speedHolding = 5.0f; // how fast the player goes when they are holding an object. 
    public float jumpforce = 200; // how much force to apply to the player for jump.
    public float hightLimit; 
    void Update()
    {

        float horz = Input.GetAxisRaw("Horizontal"); // get input from unity horizontal input. 
        if(horz < -0.01f)// if 'A' or left arrow is presses 
        {
            transform.localScale = new Vector3(-1, 1, 1); // flip sprite to look left 
        }
        else { // if horz is grater then 0.01f
            transform.localScale = new Vector3(1, 1, 1); // flip sprite to look right 
        }
        if(!isHolding)// if the player is not holding an item 
        {
            transform.Translate(Vector2.right * ((speed * horz) * Time.deltaTime)); // move at normal speed
        }
        else // if the player is holding an item 
        {
            transform.Translate(Vector2.right * ((speedHolding * horz) * Time.deltaTime)); // move at holding speed 
        }
       
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {// if the player presses down and the player is grounded. 
            isGrounded = false; // grounded is false
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0); // reset upforce 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce); // add force to rigidbody
        }
        // if the player presses down arrow or 'S' while holding an object 
        if(Input.GetKeyDown(KeyCode.DownArrow) && isHolding || Input.GetKeyDown(KeyCode.S) && isHolding) 
        {
            isHolding = false; // player is no longer holding an object 
            Instantiate(rad, heldBomb.transform.position, Quaternion.identity); // create rad at the held point 
            heldBomb.SetActive(false); // hide the holding image on the player
        }

        if(transform.position.y < -6) // if I fall below a point in the game world 
        {
            transform.position = startingPos; // reset my posision to my starting point
        }
        if(transform.position.x > limits.y) // limit my movement to the right
        {
            transform.position = new Vector3(limits.y, transform.position.y, transform.position.z); // enforce the limitation 
        }
        if(transform.position.x < limits.x) //limits my movement to the left
        {
            transform.position = new Vector3(limits.x, transform.position.y, transform.position.z); // enforce the limitation 
        }
        if(transform.position.y > hightLimit) //limits my hight
        {
            transform.position = new Vector3(transform.position.x, hightLimit, transform.position.z); // enforce the limitation 
        }
    }
    public GameObject rad; // store prefab for the rad 
    private void OnTriggerStay2D(Collider2D other) // when the player triggers on the ground
    {
            isGrounded = true; // I am now grounded
    }
    public GameObject heldBomb; // image for rad holding to be displayed 
    private void OnTriggerEnter2D(Collider2D other) // when i collide with another object 
    {
        if(other.gameObject.tag == "Bomb" && !isHolding) // if the other object is tagged as bomb 
        {
            isHolding = true; // player is not holding an object 
            heldBomb.SetActive(true); // display object that player is holding 
            other.gameObject.GetComponent<Bomb_Holder>().Hide(); // tell other object to hide its self
        }
    }
}
