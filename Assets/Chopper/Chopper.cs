using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopper : MonoBehaviour
{
    public float scrollSpeed;
    public Vector2 moveSpeed = new Vector2(5, 4);
    public Camera mainCamera;
    Vector2 widthThresold = new Vector2(0, Screen.width);
    Vector2 heightThresold = new Vector2(0, Screen.height);   

    private float objectWidth;
    private float objectHeight;
    private Vector2 screenBounds;

    private float startPos;

    void Start()
    {
        startPos = Camera.main.transform.position.x;           
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x * 1.3f;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;    
    }

    void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;                                
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.Translate(scrollSpeed * delta, 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, inputX * -5);
        transform.Translate(moveSpeed.x * inputX * delta, moveSpeed.y * inputY * delta, 0, Space.World);     
    }

    void LateUpdate() {                    
        Vector3 viewPos = transform.position;
        
        viewPos.x = Mathf.Clamp(viewPos.x,
            screenBounds.x + objectWidth + Camera.main.transform.position.x,
            screenBounds.x * -1 - objectWidth + Camera.main.transform.position.x);
        
        viewPos.y = Mathf.Clamp(viewPos.y,
            screenBounds.y * -1 + objectHeight,
            screenBounds.y - objectHeight);
        
        transform.position = viewPos;
    }
    
}
