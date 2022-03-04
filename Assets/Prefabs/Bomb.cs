using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject explosion;
    float speedMax = 10f;

    Vector2 widthThreshold = new Vector2(0, Screen.width);
    Vector2 heightThreshold = new Vector2(0, Screen.height);

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
 
    private bool offScreen() {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return (screenPosition.x < widthThreshold.x || screenPosition.x > widthThreshold.y || screenPosition.y < heightThreshold.x || screenPosition.y > heightThreshold.y);        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {                
        if (other.gameObject.tag == "Ground") {            
            explode();            
        }
    }

    private void explode() {
        Vector3 pos = transform.position;
        Vector3 extents = explosion.GetComponent<SpriteRenderer>().bounds.extents;
        pos += new Vector3(0, extents.y -0.5f, 0);
        Instantiate(explosion, pos, new Quaternion());
        Destroy(gameObject);
    }
}
