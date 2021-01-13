using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviCursor : MonoBehaviour
{
    public GameObject towerMenuDealer;
    public GameObject towerAddingPanel;
    public GameObject player;

    bool eMenu=false;
    bool pMenu=false;

    public Transform cursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void button1Click()
    {
        towerAddingPanel.SetActive(false);
        pMenu = false;
        Time.timeScale = 1f;
        player.GetComponent<Control>().enabled = true;
        Cursor.visible = false;
    }

    public void button2Click()
    {
        towerAddingPanel.SetActive(false);
        pMenu = false;
        Time.timeScale = 1f;
        player.GetComponent<Control>().enabled = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cursor.transform.position, cursor.transform.forward, out hit, 5);
        var whatBeenHit = hit.transform.gameObject.GetComponent<EmptyForCursor>();




        if (whatBeenHit != null && pMenu == false)
        {
            towerMenuDealer.SetActive(true);
            eMenu = true;
            if (Input.GetKeyDown(KeyCode.E) && eMenu == true)
            {
                player.GetComponent<Control>().enabled = false;
                Cursor.visible = true;
                towerMenuDealer.SetActive(false);
                eMenu = false;
                towerAddingPanel.SetActive(true);
                pMenu = true;
                Time.timeScale = 0f;

            }
            
        }
        if (whatBeenHit == null)
        {
            towerMenuDealer.SetActive(false);
            eMenu = false;
        }

    }
}
