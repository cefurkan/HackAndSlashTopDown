using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDir;
    Rigidbody2D rb;
    public float speed = 100f;
    bool isDashingButtonDown = false;
    public float doubleDashCoolDown;
    public int dashCounter;
    public bool doubleDashTimer;
    public int maxDashAmount = 2;
    public float dashTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
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

            if (dashTimer >= 1)
            {
                dashCounter = maxDashAmount;
            }
            if (dashTimer >= 4)
            {
                dashCounter = 0;
                dashTimer = 0;
            }
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = moveDir.normalized * speed * Time.fixedDeltaTime;
        if (isDashingButtonDown)
        {
            dashCounter++;
            float dashAmount = 40f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;

            if (moveDir != Vector3.zero)
            {
                rb.velocity = dashPosition;
            }
            isDashingButtonDown = false;
        }
     
    }
}
