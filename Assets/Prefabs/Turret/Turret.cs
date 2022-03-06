using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : Enemy
{
    float heightThreshold;

    void Start()
    {
        heightThreshold = -0.5f;
    }

    private void FixedUpdate()
    {
        aimCanon();
    }

    private void aimCanon()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        Vector3 posDelta = playerPos - myPos;

        Animator anim = GetComponent<Animator>();
        int layerIndex = anim.GetLayerIndex("Base Layer");
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(layerIndex);        

        // LOW
        if (stateInfo.IsName("Idle Left Low"))
        {            
            if (posDelta.x > 0) anim.Play("rotate Right Low");
            else if (posDelta.y + heightThreshold > 0) anim.Play("up Left");                
        }

        else if (stateInfo.IsName("Idle Right Low"))
        {
            if (posDelta.x < 0) anim.Play("rotate Left Low");
            else if (posDelta.y + heightThreshold > 0) anim.Play("up Right");    
        }

        // HIGH 
        else if (stateInfo.IsName("Idle Left High"))
        {
            if (posDelta.x > 0) anim.Play("rotate Right High");
            else if (posDelta.y + heightThreshold < 0) anim.Play("down Left");            
        }
        
        
        else if (stateInfo.IsName("Idle Right High"))
        {
            if (posDelta.x < 0) anim.Play("rotate Left High");
            else if (posDelta.y + heightThreshold < 0) anim.Play("down Right");
        }



    }
}
