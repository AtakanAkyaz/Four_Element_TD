using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOver;
    

    // Update is called once per frame
    void Update()
    {
        if (Lives.life <= 0)
        {
            Debug.Log("Oyun bitti");
            GameOver.SetActive(true);
        }
    }
}
