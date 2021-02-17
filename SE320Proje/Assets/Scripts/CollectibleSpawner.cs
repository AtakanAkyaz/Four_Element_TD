using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    private float spawnTime;
    public GameObject ignot;
    public GameObject heart;
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

    public void spawnCollectibleHeart()
    {
        x = Random.value * 50;
        z = Random.value * 50;
        Instantiate(heart, new Vector3(x, 3.5f, z), Quaternion.Euler(-90f, 90f, 0f));
        spawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= 10f)
        {
            float y = Random.Range(0f, 1f);
            if (y >= 0.95)
            {
                spawnCollectibleHeart();
            }
            else
            {
                spawnCollectible();
            }
        }
    }
}
