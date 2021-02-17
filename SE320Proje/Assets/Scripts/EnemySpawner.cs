using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public int WaveCounter = 5;
    private float WaveTime = 0f;
    public Transform SpawnPoint;
    public GameObject Enemy;
    public GameObject BigEnemy;
    public GameObject FastEnemy;
    public static float DistanceMoved = 0;


  
    
   
    private void Update()
    {
        if (WaveTime >= 30f && WaveCounter != 0)
        {
            StartCoroutine(SpawnEnemies());
            WaveTime = 0f;
            WaveCounter--;
        }

        WaveTime += Time.deltaTime;

        if (global::Enemy.enemyDistanceMoved > DistanceMoved)
        {
            DistanceMoved = global::Enemy.enemyDistanceMoved;
        }

        if (global::BigEnemy.bigEnemyDistanceMoved > DistanceMoved)
        {
            DistanceMoved = global::BigEnemy.bigEnemyDistanceMoved;
        }
        if (global::FastEnemy.fastEnemyDistanceMoved > DistanceMoved)
        {
            DistanceMoved = global::FastEnemy.fastEnemyDistanceMoved;
        }
    }

    IEnumerator SpawnEnemies()
    {
        if (WaveCounter == 5)
        {
            for (int i = 0; i < 7; i++)
                    {
                        SpawnEnimie();
                        yield return new WaitForSeconds(1f);
                    }
        }
        else if (WaveCounter == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                SpawnBigEnimie();
                yield return new WaitForSeconds(1f);
            }
        }
        else if (WaveCounter == 3)
        {
            for (int i = 0; i < 7; i++)
            {
                SpawnFastEnimie();
                yield return new WaitForSeconds(1f);
            }
        }
        else if (WaveCounter == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnFastEnimie();
                yield return new WaitForSeconds(1f);
            }

            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(1f);
                SpawnBigEnimie();
            }
        }
        else if (WaveCounter == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnFastEnimie();
                yield return new WaitForSeconds(1f);
            }

            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(1f);
                SpawnBigEnimie();
                yield return new WaitForSeconds(1f);SpawnEnimie();
            }
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 3; i++)
            {
                SpawnFastEnimie();
                yield return new WaitForSeconds(1f);
            }
        }
        
    }

    void SpawnEnimie()
    {
        Instantiate(Enemy, SpawnPoint.position,  Quaternion.Euler(0, 90, 0));
        
    } 
    void SpawnBigEnimie()
    {
        Instantiate(BigEnemy, SpawnPoint.position,  Quaternion.Euler(0, 90, 0));
        
    }
    void SpawnFastEnimie()
    {
        Instantiate(FastEnemy, SpawnPoint.position,  Quaternion.Euler(0, 90, 0));
        
    }
}