using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

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
        rb.velocity = inputManager.moveDirection *( moveSpeed * Time.fixedDeltaTime);

        DashPhysics();
    }
 
    private void DashPhysics()
    {
        if (inputManager.isDashingButtonDown)
        {
            inputManager.dashCounter++;
            Vector3 dashPosition = transform.position + inputManager.moveDirection * inputManager.dashAmount;

            if (inputManager.moveDirection != Vector3.zero)
            {
                rb.velocity = dashPosition;
            }
           inputManager.isDashingButtonDown = false;
        }
    }
}
