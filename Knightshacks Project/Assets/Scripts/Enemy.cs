using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, CollisionHandler
{
    public static Enemy mob;

    public Transform body;

    public int health = 5;

    public float bodyDamage;

    public GameObject coin;

    public Transform GetBody()
    {
        return body;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(coin, new Vector3(body.position.x, body.position.y + 0.5f, body.position.z), body.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("TOUCHING!");
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeHealth(bodyDamage);
        }
    }
}
