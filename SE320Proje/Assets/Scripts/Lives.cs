using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    public Text LivesText;

    private void Update()
    {
        LivesText.text = "Lives : " + (EnemyOnEndPoint.Lives).ToString();
    }
}
