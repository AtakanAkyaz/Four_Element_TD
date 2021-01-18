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

        if (fireTime >= 1f)
        {
            Fire();
            fireTime = 0;
        }

        fireTime += Time.deltaTime;
    }

    private void SearchTarget()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in Enemy)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
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