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
        Money.money += 100;
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
        if ( Turret.towerLevelCnt == 2)
        {
            if (Money.money >= 200)
            {
                Turret.towerLevel = 2;
                Turret.towerLevelCnt += 1;
            }
            else
            {
                // paran yetersiz bildirimi
            }
            
        }
        
        else if ( Turret.towerLevelCnt == 3)
        {
            if (Money.money >= 1200)
            {
                Turret.towerLevel = 3; 
            }
            else
            {
                // paran yetersiz bildirimi
            }
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
        
        

        if(isTower!=null && sellUpgradePanelOpen == false)
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
