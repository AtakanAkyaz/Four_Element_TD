using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public CharacterController controller;
    public Transform ccamera;
    public Transform spawnPoint;

    public float speed = 6f;
    private Vector3 newDirection;

    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    
    public float gravity = -9.81f;

    private Vector3 gravityV;
    private Vector3 jumpV;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + ccamera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        if (direction.magnitude >= 0.01f)
        {
            newDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        else
        {
            newDirection = Vector3.zero;
        }
        
        
        
        gravityV.y += gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                jumpV = Vector3.up * 5f;
            }
            else
            {
                jumpV = Vector3.zero;
            }

            gravityV.y = -1f;
        }



        if (GameObject.Find("Canvas").GetComponent<Mapping>().mapActive == true)
        {
            controller.Move((direction * speed + gravityV + jumpV) * Time.deltaTime);
        }

        if (GameObject.Find("Canvas").GetComponent<Mapping>().mapActive == false)
        {
            controller.Move((newDirection * speed + gravityV + jumpV) * Time.deltaTime);
        }

        if (transform.position.y < -5)
        {
            transform.position = spawnPoint.position;
        }


    }
}
