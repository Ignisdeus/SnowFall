using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Check : MonoBehaviour
{
    public GameObject floor;
    public GameObject player;
    public Text timer, gameOver;

    bool timerActive = true;
    float timerValue = 0f; 
    private void Update()
    {
        if(timerActive)
        {
            timerValue += Time.deltaTime;
        }
        else
        {
            gameOver.text = "Press Space to Play again"; 
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneBuildIndex:0);
            }
        }

        timer.text = ((int)timerValue).ToString(); 
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "GameOver")
        {
            timerActive = false; 
            Debug.Log("GameOver");
            floor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player.SetActive(false); 
        }
    }
}
