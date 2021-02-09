using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BigEnemy : MonoBehaviour
{
    public int BigEnemyHeal = 150;

    public void Update()
    {
        
        if (BigEnemyHeal <= 0)
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
                BigEnemyHeal -= Bullet1Damage;
            }
            if(Turret.towerLevel == 2)
            {
                Random random = new Random();
                int Bullet1Damage = random.Next(33, 43);
                BigEnemyHeal -= Bullet1Damage;
            }
            if(Turret.towerLevel == 3)
            {
                Random random = new Random();
                int Bullet1Damage = random.Next(100, 101);
                BigEnemyHeal -= Bullet1Damage;
            }
            // End of damage taken from turret
           
        }
    }

    //player damaged
}
