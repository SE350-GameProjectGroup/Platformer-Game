using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformAuto : MonoBehaviour
{
    public float moveSpeed = 3f;
    bool moveRight = true;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (moveRight == true)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "StopperRight") // sağdaki collidera çarpınca sola gitmeye başlıyor
        {
            moveRight = false;
            
        }
        if (other.gameObject.tag == "StopperLeft")
        {
            moveRight = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            
           // other.collider.transform.SetParent(transform); // oyuncuyla birlikte hareket etmesini sağlıyor.
            Debug.Log("moving true");
        }
    }
}
