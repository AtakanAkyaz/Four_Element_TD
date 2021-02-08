using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    
    
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
           // Damage taken from tower
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
           // End of damage taken from tower
           
       }
    }

    //player damaged
}
