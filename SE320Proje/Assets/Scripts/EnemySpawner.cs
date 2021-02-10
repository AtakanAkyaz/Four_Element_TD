using System;
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public int WaveCounter = 5;
    private float WaveTime = 0f;
    public Transform SpawnPoint;
    public GameObject WhichEnemyWillSpawned;

    private void Update()
    {
        if (WaveTime >= 5f && WaveCounter != 0)
        {
            StartCoroutine(SpawnEnemies());
            WaveTime = 0f;
            WaveCounter--;
        }

        WaveTime += Time.deltaTime;
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnEnimie();
            yield return new WaitForSeconds(0.7f);
        }
    }

    void SpawnEnimie()
    {
        Instantiate(WhichEnemyWillSpawned, SpawnPoint.position,  Quaternion.Euler(0, 90, 0));
    }
}