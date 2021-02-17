using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyOnEndPoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag.Equals("Enemy")){
            Destroy(collider.gameObject);
            if (collider.transform.localScale.y == 2)
            {
                Lives.life -= 4;
            }
            else
            {
                Lives.life -= 1;
            }
        }
    }
}
