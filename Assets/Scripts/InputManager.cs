using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerController player;

    public Vector3 moveDirection;


    public void MovementInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;
    }

    public void DashInput()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.dashCounter < player.maxDashAmount)
            {
                player.isDashingButtonDown = true;
            }

        }
        player.Dash();


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
