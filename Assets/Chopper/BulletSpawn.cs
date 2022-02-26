using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
   public GameObject bullet;
   public Transform spawnPoint;
   public float fireRate = 0.1f;
   float lastFired = 0f;
   
   void Start() {
       lastFired = Time.timeSinceLevelLoad;
   }

   private void FixedUpdate() {
       
       float time = Time.time;
       float fireElapsed = time - lastFired;       
       bool shoot = (Input.GetKey("right shift") && (fireElapsed > fireRate));
       if (shoot) {
           Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);           
           lastFired = time;
       }
   }
}
