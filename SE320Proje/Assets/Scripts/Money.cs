using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public Text MoneyText;
    public static int money = 1000;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "Money : " + (money).ToString() + " " + Turret.towerLevel.ToString();
    }
}
