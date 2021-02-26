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
    public Vector3 moveDirection;
    [SerializeField] private float moveSpeed = 200f;

    [Header("Component")]
    Rigidbody2D rb;
    public Camera mainCamera;

    Vector3 mousePos;
    public Vector2 lookDir;
    public float angle;


    private void Awake()
    {
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MouseInput();
        MovementInput();
        Dash();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * (moveSpeed * Time.fixedDeltaTime);

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
            Vector3 dashPosition = transform.position + (moveDirection * dashAmount);

            if (moveDirection != Vector3.zero)
            {
                rb.velocity = dashPosition;
            }
            isDashingButtonDown = false;
        }
    }
    private void MovementInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;
    }

    private void MouseInput()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    public void AttackInputs(Weapons weapons)
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapons.LightAttack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            weapons.HeavyAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            weapons.SpecialAttack();
        }
    }
}
