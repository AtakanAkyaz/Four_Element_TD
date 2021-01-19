using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    private float spawnTime;
    public GameObject ignot;
    private float x;
    private float z;
    
    void Start()
    {
        
    }

    public void spawnCollectible()
    {
        x = Random.value * 50;
        z = Random.value * 50;
        Instantiate(ignot, new Vector3(x, 3f, z), Quaternion.Euler(-180f, 0.49f, -54.08f));
        spawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= 5f)
        {
            spawnCollectible();
        }
    }
}
