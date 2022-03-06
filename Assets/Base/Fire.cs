using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject explosion;
    public int power;

    Vector2 widthThreshold = new Vector2(0, Screen.width);
    Vector2 heightThreshold = new Vector2(0, Screen.height);

    public void CheckEnemyCollision(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.takeDamage(power);
        }
    }

    protected bool offScreen()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return (screenPosition.x < widthThreshold.x || screenPosition.x > widthThreshold.y || screenPosition.y < heightThreshold.x || screenPosition.y > heightThreshold.y);
    }

}
