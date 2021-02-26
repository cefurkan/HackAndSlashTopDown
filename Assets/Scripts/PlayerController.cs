using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Dash")]
    public bool isDashingButtonDown = false;
    public int dashCounter;
    public int maxDashAmount = 2;
    private float dashTimer = 0f;
    [SerializeField] private float dashCoolDown = 1f;
    public float dashAmount = 40f;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 200f;

    [Header("Component")]
    Rigidbody2D rb;
    InputManager inputManager;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputManager.MovementInput();
        inputManager.DashInput();

    }

    private void FixedUpdate()
    {
        //Move
        rb.velocity = inputManager.moveDirection * (moveSpeed * Time.fixedDeltaTime);

        DashPhysics();
    }

    public void Dash()
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

            if (dashTimer >= .45f)
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
            Vector3 dashPosition = transform.position + (inputManager.moveDirection * dashAmount);

            if (inputManager.moveDirection != Vector3.zero)
            {
                rb.velocity = dashPosition;
            }
            isDashingButtonDown = false;
        }
    }
}
