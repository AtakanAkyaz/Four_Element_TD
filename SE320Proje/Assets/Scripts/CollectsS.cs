using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectsS : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 25f * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.gameObject);
        Money.money += 100;
    }

}
