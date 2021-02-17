using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    
public class EmptyForTower : MonoBehaviour
{
    public GameObject towerHead;
    public GameObject RapidTowerHead;
    public GameObject SniperTowerHead;
    private void Update()
    {
        if (Turret.towerLevel == 2)
        {
            towerHead.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (Turret.towerLevel == 3)
        {
            towerHead.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
        if (RapidTurret.rapidTowerLevel == 2)
        {
            RapidTowerHead.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (RapidTurret.rapidTowerLevel == 3)
        {
            RapidTowerHead.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
        if (SniperTower.sniperTowerLevel == 2)
        {
            SniperTowerHead.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (SniperTower.sniperTowerLevel == 3)
        {
            SniperTowerHead.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
    }
}
