using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour, CollisionHandler
{
    public static MobAI mob;

    public Transform body;

    public int health = 5;

    public float bodyDamage;

    public GameObject coin;

    

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

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.player.TakeHit();
        }
    }
}
