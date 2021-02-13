using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidBullet : MonoBehaviour
{
    public Transform target;
    float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        Vector3 dir = target.position - transform.position;
        float bulletSpeed = speed * Time.deltaTime;
        transform.Translate(dir.normalized * bulletSpeed, Space.World);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    public void Fallow(Transform exactTarget)
    {
        target = exactTarget;
    }
}