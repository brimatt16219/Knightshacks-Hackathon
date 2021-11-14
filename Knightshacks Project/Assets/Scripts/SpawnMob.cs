using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public Transform area;

    public GameObject mob;

    public float time;

    public int num = 20;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            StartCoroutine(Spawn(time));
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(mob, area.position, area.rotation);
    }
}
