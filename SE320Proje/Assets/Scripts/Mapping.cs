using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapping : MonoBehaviour
{
    public GameObject tpsCamera;
    public Camera tpsCameraC;
    public Camera miniMapCameraC;
    public GameObject miniMapCamera;
    public GameObject cinemachine;
    public Transform mapCamera2Point;
    public bool mapActive;
    public float scaleOfMiniMap = 300f;
    public Slider scaleOfMiniMapSlider;
    void Start()
    {
        mapActive = false;
        miniMapCameraC.pixelRect = new Rect(0, 0, 300, 300);
    }

    public void miniMapUpdate()
    {
        scaleOfMiniMap = scaleOfMiniMapSlider.value;
        miniMapCameraC.pixelRect = new Rect(0, 0, scaleOfMiniMap, scaleOfMiniMap);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!mapActive)
            {
                cinemachine.SetActive(false);
                miniMapCamera.SetActive(false);
                tpsCamera.transform.position = mapCamera2Point.position;
                tpsCamera.transform.rotation = mapCamera2Point.rotation;
                tpsCameraC.fieldOfView = 75f;
                mapActive = true;
            }

            else
            {
                cinemachine.SetActive(true);
                miniMapCamera.SetActive(true);
                mapActive = false;
            }
        }

        

        


    }
}
