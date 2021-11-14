using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public Transform area;

    public Transform area2;

    public Transform area3;

    public Transform area4;

    public GameObject mob;

    public GameObject mob2;

    public GameObject mob3;

    public GameObject mob4;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(mob, area.position, area.rotation);

            Instantiate(mob2, area2.position, area2.rotation);

            Instantiate(mob3, area3.position, area3.rotation);

            Instantiate(mob4, area4.position, area4.rotation);

            Destroy(gameObject);
        }
    }

    
}
