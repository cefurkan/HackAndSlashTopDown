using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    Vector3 moveDirection;
    [SerializeField] private float moveSpeed = 200f;

    [Header("Dash")]
    bool isDashingButtonDown = false;
    private int dashCounter;
    private int maxDashAmount = 2;
    private float dashTimer = 0f;
    private float dashCoolDown = 1.5f;
    private float dashAmount = 40f;

    [Header("Component")]
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementInput();

        DashInput();
    }

    private void FixedUpdate()
    {
        //Move
        rb.velocity = moveDirection *( moveSpeed * Time.fixedDeltaTime);

        DashPhysics();
    }


    private void MovementInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;
    }

    private void DashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         if (dashCounter < maxDashAmount)
            {
                isDashingButtonDown = true;
            }
        }

        if (dashCounter >= 1)
        {
            dashTimer += Time.deltaTime;

            if (dashTimer >= .75f)
            {
                dashCounter = maxDashAmount;
            }
            if (dashTimer >= dashCoolDown)
            {
                dashCounter = 0;
                dashTimer = 0;
            }
        }
    }
    private void DashPhysics()
    {
        if (isDashingButtonDown)
        {
            dashCounter++;
            Vector3 dashPosition = transform.position + moveDirection * dashAmount;

            if (moveDirection != Vector3.zero)
            {
                rb.velocity = dashPosition;
            }
            isDashingButtonDown = false;
        }
    }
}
