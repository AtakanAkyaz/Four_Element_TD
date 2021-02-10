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
    public static float distanceMoved = 0;
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
        distanceMoved += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }
    
    public float healthPercentage()
    {
        return   healthBarSlider.value =health / maxHealth;
    }
}
