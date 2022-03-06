using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Fire
{    
    public float speed = 30.0f;
    
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckEnemyCollision(other);
        explode();        
    }

    private void explode()
    {
        Instantiate(explosion, transform.position, new Quaternion());
        Destroy(gameObject);
    }
}
