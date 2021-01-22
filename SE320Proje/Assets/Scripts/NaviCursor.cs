using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviCursor : MonoBehaviour
{
    public GameObject towerMenuDealer;
    public GameObject towerAddingPanel;

    public Material highlightedColor;
    public Material normalColor;

    private Renderer selection;
    bool eMenu=false;
    static public bool pMenu;

    public GameObject tower1;
    private Transform towerPoint;
    private GameObject towerPointObject;
    public Transform cursor;
   
    void Start()
    {
        pMenu = false;
    }
   
    public void button1Click()
    {
        if (Money.money >= 200)
        {
            Instantiate(tower1, towerPoint.position , towerPoint.rotation);
            Money.money -= 200;
            Destroy(towerPointObject);
        }
        
        towerAddingPanel.SetActive(false);
        pMenu = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void button2Click()
    {
        towerAddingPanel.SetActive(false);
        pMenu = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cursor.transform.position, cursor.transform.forward, out hit, 10f);

        Vector3 cursorForward = cursor.TransformDirection(Vector3.forward) * 10f;
        Debug.DrawRay(cursor.transform.position, cursorForward, Color.green);

        var whatBeenHit = hit.transform;
        towerPoint = whatBeenHit;
        towerPointObject = whatBeenHit.gameObject;
        var isTowerPoint=whatBeenHit.gameObject.GetComponent<EmptyForCursor>();
        var whatRendererHit = whatBeenHit.GetComponent<Renderer>();

        if (isTowerPoint != null && pMenu == false)
        {
            towerMenuDealer.SetActive(true);
            eMenu = true;
            whatRendererHit.material = highlightedColor;
            selection = whatRendererHit;

            if (Input.GetKeyDown(KeyCode.E) && eMenu == true)
            {
                Cursor.visible = true;
                towerMenuDealer.SetActive(false);
                eMenu = false;
                towerAddingPanel.SetActive(true);
                pMenu = true;
                Time.timeScale = 0f;
               

            }
            
        }
        if (isTowerPoint == null)
        {
            towerMenuDealer.SetActive(false);
            eMenu = false;
            selection.material = normalColor;
        }

    }
}
