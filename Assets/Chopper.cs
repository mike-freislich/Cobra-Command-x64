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

    private float startPos;

    void Start()
    {
        startPos = mainCamera.transform.position.x;
    }

    void FixedUpdate()
    {
        float delta = Time.deltaTime;        

        //float dist = (startPos - mainCamera.transform.position.x);
        transform.Translate(scrollSpeed * delta, 0, 0);


        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.localEulerAngles = new Vector3(0, 0, inputX * -5);

        transform.Translate(moveSpeed.x * inputX * delta, moveSpeed.y * inputY * delta, 0, Space.World);
        
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < widthThresold.x) || (screenPosition.x > widthThresold.y) || (screenPosition.y < heightThresold.x) || (screenPosition.y > heightThresold.y)) {
            //transform.Translate(-1 * moveSpeed.x * inputX * delta, -1 * moveSpeed.y * inputY * delta, 0, Space.World);
        }        

    }
}
