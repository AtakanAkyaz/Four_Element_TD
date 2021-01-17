using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyOnEndPoint : MonoBehaviour
{

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("EndPoint")){
            Destroy(gameObject);
            EndPoint.Lives--;
        }

        
    }
}
