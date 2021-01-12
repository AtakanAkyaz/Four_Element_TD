using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyOnEndPoint : MonoBehaviour
{

    public static int Lives = 20;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("EndPoint")){
            gameObject.SetActive(false);
            Lives--;
        }
    }
}
