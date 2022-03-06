using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{


    public int health;

    public GameObject explosion;
    private GameObject playerObject;

    public int currentHealth { get { return health; } }

    public Enemy() : base()
    {

    }

    private Vector2 widthThreshold = new Vector2(0, Screen.width);
    private Vector2 heightThreshold = new Vector2(0, Screen.height);

    protected bool offScreen()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return (screenPosition.x < widthThreshold.x || screenPosition.x > widthThreshold.y || screenPosition.y < heightThreshold.x || screenPosition.y > heightThreshold.y);
    }

    private void Awake()
    {
        if (playerObject == null)
        {
            playerObject = GameObject.FindWithTag("Player");
            Debug.Log("PlayerObject : " + playerObject);
        }
    }

    public GameObject player
    {
        get
        {
            return playerObject;
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            explode();
    }

    protected virtual void explode()
    {
        Vector3 pos = transform.position;
        Vector3 extents = explosion.GetComponent<SpriteRenderer>().bounds.extents;
        pos += new Vector3(0, extents.y - 0.5f, 0);
        Instantiate(explosion, pos, new Quaternion());
        Destroy(gameObject);
    }
}
