using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public float distance = 0;
    public Vector3 pLocation;

    public void Start()
    {
        InvokeRepeating("calculateDistance", 0f, 0.5f);
    }
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
           // Damage taken from turret
           if(Turret.towerLevel == 1)
           {
              Random random = new Random();
                         int Bullet1Damage = random.Next(23, 33);
                         health -= Bullet1Damage;
           }
           if(Turret.towerLevel == 2)
           {
               Random random = new Random();
               int Bullet1Damage = random.Next(33, 43);
               health -= Bullet1Damage;
           }
           if(Turret.towerLevel == 3)
           {
               Random random = new Random();
               int Bullet1Damage = random.Next(100, 101);
               health -= Bullet1Damage;
           }
           // End of damage taken from turret
           
       }
    }

    //player damaged

    private void calculateDistance()
    {
        distance += Vector3.Distance(transform.position, pLocation);
        pLocation = transform.position;
    }
}
