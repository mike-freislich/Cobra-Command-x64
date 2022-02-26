using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 2.0f;
    float speedMax = 10f;
    public Camera mainCamera;
    Vector2 widthThreshold = new Vector2(0, Screen.width);
    Vector2 heightThreshold = new Vector2(0, Screen.height);

    float boostDelay = 0.3f;
    float boostAcceleration =  15f; 
    float boostTime;

    void Start()
    {       boostTime = Time.timeSinceLevelLoad;
            mainCamera = Camera.main;
    }
    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > boostTime + boostDelay) {
            speed += boostAcceleration * Time.deltaTime;
            speed = Mathf.Min(speed, speedMax);
        }
        float delta = Time.deltaTime;
        transform.Translate(speed * delta, 0, 0);

        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThreshold.x || screenPosition.x > widthThreshold.y || screenPosition.y < heightThreshold.x || screenPosition.y > heightThreshold.y)
        {
            Destroy(gameObject);
        }


    }
}
