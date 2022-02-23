using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    public float speed = 30.0f;
    public Camera mainCamera;
    Vector2 widthThresold = new Vector2(0,Screen.width);
    Vector2 heightThresold = new Vector2(0,Screen.height);

    void Start()
    {
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        float delta = Time.deltaTime;
        transform.Translate(speed * delta, 0, 0);


        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);        
        if (screenPosition.x < widthThresold.x ||screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y) {            
            Destroy(gameObject);            
        }
           
            
    }
}
