using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;
    private bool moving;
    [SerializeField] private Vector2 pos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moving = true;
            collision.collider.transform.SetParent(transform); // oyuncuyla birlikte hareket etmesini sağlıyor.
            Debug.Log("moving true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            moving = false;
            Debug.Log("moving false");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);

        }
        if(transform.position.x > pos.x || transform.position.y > pos.y)
        {
            moving = false;
        }
    }
}
