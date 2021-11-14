using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour, CollisionHandler
{
    private CollisionHandler handler;

    private void Start()
    {
        handler = GetComponent<CollisionHandler>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        handler.CollisionEnter(gameObject.name, collision.gameObject);
    }
}
