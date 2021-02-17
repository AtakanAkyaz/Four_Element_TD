using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidTurret : MonoBehaviour
{
    public AudioClip rapidTurretShoot;
    public AudioSource rapidTurretSound;
    
    public float range = 7f;
    public float fireTime = 0f;
    public GameObject shootingObject;
    public Transform gunPoint;
    public Transform target;
    public static int rapidTowerLevel = 1;
    public static int  rapidTowerLevelCnt = 2;
    public static float tempMove =0;


    private void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.3f);
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

       
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        gameObject.transform.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);
        
        // fire spped
if(rapidTowerLevel == 1)
{
    if (fireTime >= 0.4f)
    {
        Fire();
        fireTime = 0;
    }
}
if(rapidTowerLevel == 2)
{
    if (fireTime >= 0.3f)
    {
        Fire();
        fireTime = 0;
    }
}
if(rapidTowerLevel == 3)
{
    if (fireTime >= 0.1f)
    {
        Fire();
        fireTime = 0;
    }
}

        // End of fire speed
        fireTime += Time.deltaTime;
    }

    private void SearchTarget()
    {
       
        GameObject Target = null;
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        float inRange = Mathf.Infinity; 
        float maxMoveDistance = global::EnemySpawner.DistanceMoved;
        
        foreach (GameObject enemy in Enemy)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
           
            if (maxMoveDistance > tempMove && distance <= range)
            {
                inRange = distance;
                tempMove = maxMoveDistance;
                Target = enemy;
            }
            
        }

        if (Target != null && inRange <= range)
        {
            target = Target.transform;
        }
        else 
        {
            target = null;
        }
    }

    private void Fire()
    {
        GameObject firedBullet = (GameObject) Instantiate(shootingObject, gunPoint.position, gunPoint.rotation);
        RapidBullet bullet = firedBullet.GetComponent<RapidBullet>();
        rapidTurretSound.PlayOneShot(rapidTurretShoot);
        if (bullet != null)
        {
            bullet.Fallow(target);
        }
    }

   
}