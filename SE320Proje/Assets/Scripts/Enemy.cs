using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    public GameObject healthBarCanvas;
    public Slider healthBarSlider;
    public float maxHealth = 100;
    public float health = 100;
    public static float enemyDistanceMoved = 0;
    public Vector3 lastPosition;

    public void Start()
    {
        
        InvokeRepeating("calculateDistance", 0f, 0.5f);
        InvokeRepeating("SearchTarget",0,0.1f);
        InvokeRepeating("healthPercentage",0,0.1f);
    }
    public void Update()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
            Money.money += 50;
            EnemySpawner.DistanceMoved = 0;
        }

       
    }


    public void OnTriggerEnter(Collider collider)
    {
       if(collider.gameObject.tag.Equals("Bullet"))
       {
           // Damage taken from turret
           if(Turret.towerLevel == 1)
           {
              Random random = new Random();
                         int Bullet1Damage = random.Next(17, 24);
                         health -= Bullet1Damage;
           }
           else if(Turret.towerLevel == 2)
           {
               Random random = new Random();
               int Bullet1Damage = random.Next(22, 33);
               health -= Bullet1Damage;
           }
           else if(Turret.towerLevel == 3)
           {
               Random random = new Random();
               int Bullet1Damage = random.Next(30, 40);
               health -= Bullet1Damage;
           }
           // End of damage taken from turret
           
       }
       
       if(collider.gameObject.tag.Equals("RapidBullet"))
       {
           // Damage taken from turret
           if(RapidTurret.rapidTowerLevel == 1)
           {
               Random random = new Random();
               int Bullet2Damage = random.Next(5, 7);
               health -= Bullet2Damage;
           }
           else if(RapidTurret.rapidTowerLevel == 2)
           {
               Random random = new Random();
               int Bullet2Damage = random.Next(6, 8);
               health -= Bullet2Damage;
           }
           else if(RapidTurret.rapidTowerLevel == 3)
           {
               Random random = new Random();
               int Bullet2Damage = random.Next(8, 10);
               health -= Bullet2Damage;
           }
           // End of damage taken from turret
           
       }
       
       if(collider.gameObject.tag.Equals("SniperBullet"))
       {
           // Damage taken from turret
           if(SniperTower.sniperTowerLevel == 1)
           {
               Random random = new Random();
               int Bullet3Damage = random.Next(50, 60);
               health -= Bullet3Damage;
           }
           else if(SniperTower.sniperTowerLevel == 2)
           {
               Random random = new Random();
               int Bullet3Damage = random.Next(60, 70);
               health -= Bullet3Damage;
           }
           else if(SniperTower.sniperTowerLevel == 3)
           {
               Random random = new Random();
               int Bullet3Damage = random.Next(70, 80);
               health -= Bullet3Damage;
           }
           // End of damage taken from turret
           
       }
    }

    //player damaged

    private void calculateDistance()
    {
        enemyDistanceMoved += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }
    
    public float healthPercentage()
    {
        return   healthBarSlider.value =health / maxHealth;
    }
}
