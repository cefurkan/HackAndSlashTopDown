using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InputManager : MonoBehaviour
{
    public Weapons weapons;
    public PlayerController player;

    [Header("Dash")]
  public  bool isDashingButtonDown = false;
    public int dashCounter;
    private int maxDashAmount = 2;
    private float dashTimer = 0f;
    private float dashCoolDown = 1.5f;
    public float dashAmount = 40f;

    public Vector3 moveDirection;

    public  void MovementInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;
    }

    public void DashInput()
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

    public  void AttackInputs(Weapons weapons)
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
