using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 30.0f;
    Vector2 widthThresold = new Vector2(0, Screen.width);
    Vector2 heightThresold = new Vector2(0, Screen.height);
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void FixedUpdate()
    {
        if (offScreen())
            Destroy(gameObject);
    }

    bool offScreen()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "Ground")
        explode();        
    }

    private void explode()
    {
        Instantiate(explosion, transform.position, new Quaternion());
        Destroy(gameObject);
    }
}
