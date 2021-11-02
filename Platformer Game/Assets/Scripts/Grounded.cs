using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    bool wasGrounded;
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Player.GetComponent<PlayerController>().onGround = true;
        }
        if (collision.tag == "MovingPlatform")
        {
            //    player.isGrounded = true;
            // player1.isGrounded = true;
            Player.GetComponent<PlayerController>().onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Ground")
        {
            Player.GetComponent<PlayerController>().onGround = false;
        }
        if (collision.tag == "MovingPlatform")
        {
            //   player1.isGrounded = false;
            Player.GetComponent<PlayerController>().onGround = false;
        }

        if (wasGrounded)
        {
            Debug.Log("off the ground.");
        }
    }
    
}
