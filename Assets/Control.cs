using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public CharacterController controller;
    public Transform thing;

    public float speed = 6f;
    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    
    public Transform feet;
    public float distance2ground = 0.3f;
    public LayerMask groundMask;
    public float gravity = -9.81f;

    private Vector3 velocity;

    private bool isGrounded;
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
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + thing.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
           
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }
        
        isGrounded = Physics.CheckSphere(feet.position, distance2ground, groundMask);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
