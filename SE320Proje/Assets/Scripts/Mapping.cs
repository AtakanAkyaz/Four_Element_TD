using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour
{
    public GameObject tpsCamera;
    public GameObject mapCamera2;
    public bool mapActive;
    void Start()
    {
        mapActive = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            tpsCamera.SetActive(false);
            mapCamera2.SetActive(true);
            mapActive = true;
        }
        else
        {
            tpsCamera.SetActive(true);
            mapCamera2.SetActive(false);
            mapActive = false;
        }
    }
}
