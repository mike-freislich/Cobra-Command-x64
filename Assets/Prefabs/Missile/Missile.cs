using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Fire
{
    public float acceleration;
    public float speed;
    public float maxSpeed;    
    
    void Start()
    {
        
    }
    private void FixedUpdate() {
        speed += (acceleration * Time.fixedDeltaTime);
        speed = Mathf.Min(speed, maxSpeed);
        Vector3 direction = new Vector3(0, speed * Time.fixedDeltaTime ,0);
        transform.Translate(direction);        

         if (offScreen())
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckEnemyCollision(other);
        explode();        
    }
}
