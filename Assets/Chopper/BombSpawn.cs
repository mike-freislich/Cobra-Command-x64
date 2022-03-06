using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
   [SerializeField] GameObject bomb;
   [SerializeField] Transform spawnPoint;
   [SerializeField] float fireRate = 0.1f;
   float lastFired = 0f;
   
   void Start() {
       lastFired = Time.timeSinceLevelLoad;
   }

   private void FixedUpdate() {
       
       float time = Time.time;
       float fireElapsed = time - lastFired;       
       bool shoot = (Input.GetKey("/") && (fireElapsed > fireRate));
       if (shoot) {           
           Instantiate(bomb, spawnPoint.position, spawnPoint.rotation);                      
           lastFired = time;
       }
   }
}
