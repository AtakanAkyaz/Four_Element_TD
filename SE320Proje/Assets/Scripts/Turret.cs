﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public AudioSource turretSound;
    public AudioClip turretShoot;

    public float range = 8f;
    public float fireTime = 0f;
    public GameObject shootingObject;
    public Transform gunPoint;
    public Transform target;
    public static int towerLevel = 1;
    public static int  towerLevelCnt = 2;
    public static float tempMove =0;


    private void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 1f);
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
        Bullet bullet = firedBullet.GetComponent<Bullet>();
        turretSound.PlayOneShot(turretShoot);
        if (bullet != null)
        {
            bullet.Fallow(target);
        }
    }

   
}