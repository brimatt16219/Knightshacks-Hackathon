using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    
    public float damage;

    public Transform save;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeHealth(damage);
            
            player.body.position = save.position;
            
        }
    }
}
    
