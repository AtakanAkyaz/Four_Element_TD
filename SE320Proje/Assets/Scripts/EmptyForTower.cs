using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    
public class EmptyForTower : MonoBehaviour
{
    public GameObject towerHead;
    public GameObject RapidTowerHead;
    public GameObject SniperTowerCapsule;
    private void Update()
    {
        if (Turret.towerLevel == 2)
        {
            towerHead.GetComponent<Renderer>().material.color = Color.cyan;
        }

        else if (Turret.towerLevel == 3)
        {
            towerHead.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
        else if (RapidTurret.rapidTowerLevel == 2)
        {
            RapidTowerHead.GetComponent<Renderer>().material.color = Color.cyan;
        }

        else if (RapidTurret.rapidTowerLevel == 3)
        {
            RapidTowerHead.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
        else if (SniperTower.sniperTowerLevel == 2)
        {
            SniperTowerCapsule.GetComponent<Renderer>().material.color = Color.cyan;
        }

        else if (SniperTower.sniperTowerLevel == 3)
        {
            SniperTowerCapsule.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
    }
}
