using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{

    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
    }
}
