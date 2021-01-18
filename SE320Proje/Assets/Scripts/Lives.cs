using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    public Text LivesText;
    public static int life = 1;

    private void Update()
    {
        LivesText.text = "Lives : " + (life).ToString();
    }
}
