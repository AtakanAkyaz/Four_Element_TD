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
        else if (RapidTurret.rapidTowerLevel == 1)
        {
            Money.money += 100;
        }
        else if (RapidTurret.rapidTowerLevel == 2)
        {
            Money.money += 300;
        }
        else if (RapidTurret.rapidTowerLevel == 3)
        {
            Money.money += 800;
        }
        else if (SniperTower.sniperTowerLevel == 1)
        {
            Money.money += 100;
        }
        else if (SniperTower.sniperTowerLevel == 2)
        {
            Money.money += 300;
        }
        else if (SniperTower.sniperTowerLevel == 3)
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

    public void upNormal()
    {
        sellUpgradePanel.SetActive(false);
        sellUpgradePanelOpen = false;
        Cursor.visible = false;
        Time.timeScale = 1f;

        if (Turret.towerLevelCnt == 2 && Money.money >= 400)
        {
            Turret.towerLevel = 2;
            Turret.towerLevelCnt += 1;
            Money.money -= 400;
        }

        else if (Turret.towerLevelCnt == 3 && Money.money >= 1000)
        {
            Turret.towerLevel = 3;
            Money.money -= 1000;
            Turret.towerLevelCnt += 1;
        }
        else
        {
            return;
        }
    }
    public void upRapid()
    {
        sellUpgradePanel.SetActive(false);
        sellUpgradePanelOpen = false;
        Cursor.visible = false;
        Time.timeScale = 1f;

        if (RapidTurret.rapidTowerLevelCnt == 2 && Money.money >= 400)
        {
            RapidTurret.rapidTowerLevel = 2;
            RapidTurret.rapidTowerLevelCnt += 1;
            Money.money -= 400;
        }

        else if (RapidTurret.rapidTowerLevelCnt == 3 && Money.money >= 1000)
        {
            RapidTurret.rapidTowerLevel = 3;
            RapidTurret.rapidTowerLevelCnt += 1;
            Money.money -= 1000;
        }
        else
        {
            return;
        }
    }
    public void upSniper()
    {
        sellUpgradePanel.SetActive(false);
        sellUpgradePanelOpen = false;
        Cursor.visible = false;
        Time.timeScale = 1f;

        if (SniperTower.sniperTowerLevelCnt == 2 && Money.money >= 400)
        {
            SniperTower.sniperTowerLevel = 2;
            SniperTower.sniperTowerLevelCnt += 1;
            Money.money -= 400;
        }


        else if (SniperTower.sniperTowerLevelCnt == 3 && Money.money >= 1000)
        {
            SniperTower.sniperTowerLevel = 3;
            SniperTower.sniperTowerLevelCnt += 1;
            Money.money -= 1000;
        }
        else
        {
            return;
        }
    }

    public void exitMenu()
    {
        sellUpgradePanel.SetActive(false);
        sellUpgradePanelOpen = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
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
