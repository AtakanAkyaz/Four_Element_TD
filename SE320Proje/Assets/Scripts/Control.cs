using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public CharacterController controller;
    public Transform ccamera;

    public float speed = 6f;

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
        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + ccamera.eulerAngles.y;
            //getting angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
           
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //facing forward
            controller.Move((moveDirection.normalized+gravityV+jumpV) * speed * Time.deltaTime);

        }
        
        gravityV.y += gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                jumpV = Vector3.up * 4;
            }
            else
            {
                jumpV = Vector3.zero;
            }

            gravityV.y = -2f;
        }

        controller.Move((gravityV + jumpV) * speed * Time.deltaTime);


    }
}
