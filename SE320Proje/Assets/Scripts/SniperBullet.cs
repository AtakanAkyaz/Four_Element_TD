using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    public Transform target;
    float speed = 30f;

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

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    public void Fallow(Transform exactTarget)
    {
        target = exactTarget;
    }
}
