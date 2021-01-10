using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyOnEndPoint : MonoBehaviour
{

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("EndPoint")){
            gameObject.SetActive(false);
        }
    }
}
