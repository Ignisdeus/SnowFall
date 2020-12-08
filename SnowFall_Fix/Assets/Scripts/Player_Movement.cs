using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Vector3 startingPos;
    public Vector2 limits; 
    void Start()
    {
        startingPos = transform.position; 
    }
    public bool isGrounded = true, isHolding = false; 
    public float speed = 10.0f, speedHolding= 5.0f, jumpforce = 200; 
    void Update()
    {

        float horz = Input.GetAxisRaw("Horizontal");
        if(horz < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(!isHolding)
        {
            transform.Translate(Vector2.right * ((speed * horz) * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector2.right * ((speedHolding * horz) * Time.deltaTime));
        }
       
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isGrounded = false; 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && isHolding || Input.GetKeyDown(KeyCode.S) && isHolding)
        {
            isHolding = false;
            Instantiate(rad, heldBomb.transform.position, Quaternion.identity);
            heldBomb.SetActive(false);
        }

        if(transform.position.y < -6)
        {
            transform.position = startingPos; 
        }
        if(transform.position.x > limits.y)
        {
            transform.position = new Vector3(limits.y, transform.position.y, transform.position.z);
        }
        if(transform.position.x < limits.x)
        {
            transform.position = new Vector3(limits.x, transform.position.y, transform.position.z);
        }
    }
    public GameObject rad; 
    private void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = true; 
    }
    public GameObject heldBomb;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bomb" && !isHolding)
        {
            isHolding = true; 
            heldBomb.SetActive(true);
            other.gameObject.GetComponent<Bomb_Holder>().Hide();
        }
    }
}
