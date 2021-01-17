using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject position4;
    public GameObject position5;
    public GameObject position6;
    public GameObject position7;
    public GameObject position8;
    public GameObject position9;
    public GameObject position10;
    public GameObject endPoint;
    public float speed = 5f;


    bool p1 = true , p2 = true , p3 = true , p4 = true , p5 = true , p6 = true , p7 = true , p8 = true , p9 = true , p10 = true , pEnd = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position1.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position1.transform.position)
                {
                    p1 = false;
                };
            }
            
            else if (p2)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position2.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position2.transform.position)
                {
                    p2 = false;
                };
            }
            
            else if (p3)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position3.GetComponent<Transform>().position , speed * Time.deltaTime);
                if (gameObject.transform.position == position3.transform.position)
                {
                    p3 = false;
                };
            }
            
            else if (p4)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position4.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position4.transform.position)
                {
                    p4 = false;
                };
            }
            
            else if (p5)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position5.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position5.transform.position)
                {
                    p5= false;
                };
            }
            
            else if (p6)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position6.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position6.transform.position)
                {
                    p6 = false;
                };
            }
            
            else if (p7)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position7.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position7.transform.position)
                {
                    p7 = false;
                };
            }
            
            else if (p8)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position8.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position8.transform.position)
                {
                    p8 = false;
                };
            }
            
            else if (p9)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position9.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position9.transform.position)
                {
                    p9 = false;
                };
            }
           
            else if (p10)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    position10.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == position10.transform.position)
                {
                    p10 = false;
                };
            }
            
            else if (pEnd)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    endPoint.GetComponent<Transform>().position, speed * Time.deltaTime);
                if (gameObject.transform.position == endPoint.transform.position)
                {
                    pEnd = false;
                };
            }
    }
}
