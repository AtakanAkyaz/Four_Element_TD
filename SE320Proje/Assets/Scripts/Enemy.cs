using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 30;
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Money.money += 50;
        }
    }


    public void OnCollisionEnter(Collision collusion)
    {
       if(collusion.gameObject.tag.Equals("Bullet"))
       {
           health -= 30;
       }
    }
}
