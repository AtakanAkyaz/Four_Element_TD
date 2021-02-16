using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    
public class EmptyForTower : MonoBehaviour
{
    public GameObject towerHead;
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
        
    }
}
