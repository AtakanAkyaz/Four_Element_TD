using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCursor : MonoBehaviour
{
    public Transform towerCursor;
    private GameObject towerHit;
    

    
    public static bool sellUpgradePanelOpen;
    private bool sellUpgradeTextOpen;

    public GameObject sellUpgradeText;
    public GameObject sellUpgradePanel;

    public Material highlightedColor;
    public Material towerBottomMaterial;
    private Renderer selection;

    public GameObject towerPoints;

    public void sell()
    {
        if (Turret.towerLevel == 1)
        {
            Money.money += 100;
        }
        else if (Turret.towerLevel == 2)
        {
            Money.money += 300;
        }
        else if (Turret.towerLevel == 3)
        {
            Money.money += 800;
        }
        else if (RapidTurret.towerLevel == 1)
        {
            Money.money += 100;
        }
        else if (RapidTurret.towerLevel == 2)
        {
            Money.money += 300;
        }
        else if (RapidTurret.towerLevel == 3)
        {
            Money.money += 800;
        }
        sellUpgradePanel.SetActive(false);
        sellUpgradePanelOpen = false;
        Instantiate(towerPoints, towerHit.transform.position, towerHit.transform.rotation);
        Destroy(towerHit);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void upgrade()
    {
        sellUpgradePanel.SetActive(false);
        sellUpgradePanelOpen = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
        if ( Turret.towerLevelCnt == 2 && Money.money >=400)
        {
                  Turret.towerLevel = 2;
                Turret.towerLevelCnt += 1;
                Money.money -= 400;
        }
        
        else if ( Turret.towerLevelCnt == 3 && Money.money >= 1000)
        {
                 Turret.towerLevel = 3;
                Money.money -= 1000;
        }

        else if(RapidTurret.towerLevelCnt == 2 && Money.money >= 400)
        {
                RapidTurret.towerLevel = 2;
                RapidTurret.towerLevelCnt += 1;
                Money.money -= 400;
        }

        else if (RapidTurret.towerLevelCnt == 3 && Money.money >= 1000)
        {
            RapidTurret.towerLevel = 3;
                Money.money -= 1000;
        }
    }

    void Start()
    {
        sellUpgradePanelOpen = false;
    }

    
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(towerCursor.transform.position, towerCursor.transform.forward, out hit, 10f);

        //Vector3 cursorForward = towerCursor.TransformDirection(Vector3.forward) * 10f;
        //Debug.DrawRay(towerCursor.transform.position, cursorForward, Color.red);

        var whichTowerHit = hit.transform;
        towerHit = whichTowerHit.gameObject;
        var isTower = whichTowerHit.gameObject.GetComponent<EmptyForTower>();
        var towerRendererHit = whichTowerHit.GetComponent<Renderer>();
        
        

        if( isTower != null && sellUpgradePanelOpen == false)
        {
            sellUpgradeText.SetActive(true);
            sellUpgradeTextOpen = true;
            towerRendererHit.material = highlightedColor;
            selection = towerRendererHit;

            if (Input.GetKeyDown(KeyCode.E) && sellUpgradeTextOpen == true)
            {
                Cursor.visible = true;
                sellUpgradeText.SetActive(false);
                sellUpgradeTextOpen = false;
                sellUpgradePanel.SetActive(true);
                sellUpgradePanelOpen = true;
                Time.timeScale = 0f;

            }
        }

        if (isTower == null)
        {
            sellUpgradeText.SetActive(false);
            sellUpgradeTextOpen = false;
            selection.material = towerBottomMaterial;
        }

    }
}
