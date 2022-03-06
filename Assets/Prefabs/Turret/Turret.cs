using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : Enemy
{
    public GameObject missile;
    public float waitAfterFire = 3;

    float scanHeightThreshhold;
    float lastFired;
    
    Quaternion spawnPointRotation;
    Vector3 spawnPointPosition;

    bool isMoving;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        isMoving = false;
        scanHeightThreshhold = -0.5f;
        lastFired = Time.time;
    }

    private void FixedUpdate()
    {
        if (!offScreen())
        {
            aimCanon();
            if (!isMoving && (Time.time - lastFired) > waitAfterFire)
                fireMissile();
        }
    }

    private void aimCanon()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        Vector3 posDelta = playerPos - myPos;

        int layerIndex = anim.GetLayerIndex("Base Layer");
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(layerIndex);

        if (stateInfo.IsName("Idle Left Low"))          // LOW LEFT
        {
            if (posDelta.x > 0) startMove("rotate Right Low");
            else if (posDelta.y + scanHeightThreshhold > 0) startMove("up Left");
            else setSpawnPoint("Idle Left Low");
        }

        else if (stateInfo.IsName("Idle Right Low"))    // LOW RIGHT
        {
            if (posDelta.x < 0) startMove("rotate Left Low");
            else if (posDelta.y + scanHeightThreshhold > 0) startMove("up Right");
            else setSpawnPoint("Idle Right Low");
        }

        else if (stateInfo.IsName("Idle Left High"))    // HIGH LEFT
        {
            if (posDelta.x > 0) startMove("rotate Right High");
            else if (posDelta.y + scanHeightThreshhold < 0) startMove("down Left");
            else setSpawnPoint("Idle Left High");
        }

        else if (stateInfo.IsName("Idle Right High"))   // HIGH RIGHT
        {
            if (posDelta.x < 0) startMove("rotate Left High");
            else if (posDelta.y + scanHeightThreshhold < 0) startMove("down Right");
            else setSpawnPoint("Idle Right High");
        }
    }

    private void startMove(string stateName)
    {
        isMoving = true;
        anim.Play(stateName);        
    }

    private void setSpawnPoint(string stateName)
    {
        isMoving = false;
        Vector3 pos = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        switch (stateName)
        {
            case "Idle Left Low": pos = new Vector3(-1, 0, 0); rotation = Quaternion.Euler(0, 0, 90); break;
            case "Idle Right Low": pos = new Vector3(1, 0, 0); rotation = Quaternion.Euler(0, 0, -90); break;
            case "Idle Left High": pos = new Vector3(-1, 0.5f, 0); rotation = Quaternion.Euler(0, 0, 65); break;
            case "Idle Right High": pos = new Vector3(1, 0.5f, 0); rotation = Quaternion.Euler(0, 0, -65); break;            
        }
        spawnPointPosition = transform.position + pos;
        spawnPointRotation = rotation;
    }

    private void fireMissile()
    {
        Debug.Log("firing Missile");
        Instantiate(missile, spawnPointPosition, spawnPointRotation);
        lastFired = Time.time;
    }
}
