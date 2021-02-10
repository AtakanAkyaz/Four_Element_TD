using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public float range = 12f;
    public float fireTime = 0f;
    public GameObject shootingObject;
    public Transform gunPoint;
    public Transform target;
    public static int towerLevel = 1;
    public static int  towerLevelCnt = 2;


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

       
        transform.LookAt(target); 
        // fire spped
if(towerLevel == 1)
{
    if (fireTime >= 1f)
    {
        Fire();
        fireTime = 0;
    }
}
if(towerLevel == 2)
{
    if (fireTime >= 0.8f)
    {
        Fire();
        fireTime = 0;
    }
}
if(towerLevel == 3)
{
    if (fireTime >= 0.7f)
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
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        float maxMovedEnemy = global::Enemy.distanceMoved;
        GameObject Target = null;

        foreach (GameObject enemy in Enemy)
        {
            float distance = 0;
            if (distance < maxMovedEnemy)
            {
                maxMovedEnemy = distance;
                Target = enemy;
            }
        }

        if (Target != null && maxMovedEnemy <= range)
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
        Bullet bullet = firedBullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Fallow(target);
        }
    }
    
}