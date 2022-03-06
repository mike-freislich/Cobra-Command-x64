using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Fire
{
    public float speed = 1.0f;

    float speedMax = 10f;

    float boostDelay = 0.3f;
    float boostAcceleration = 15f;
    float boostTime;

    Rigidbody2D rb;

    void Start()
    {
        boostTime = Time.timeSinceLevelLoad;
    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > boostTime + boostDelay)
        {
            speed += boostAcceleration * Time.fixedDeltaTime;
            speed = Mathf.Min(speed, speedMax);
        }
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);

        if (offScreen()) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckEnemyCollision(other);        
        explode();        
    }

    override public void explode()
    {
        Vector3 pos = transform.position;
        Vector3 extents = explosion.GetComponent<SpriteRenderer>().bounds.extents;
        pos += new Vector3(0, extents.y - 0.5f, 0);
        Instantiate(explosion, pos, new Quaternion());
        Destroy(gameObject);
    }
}
