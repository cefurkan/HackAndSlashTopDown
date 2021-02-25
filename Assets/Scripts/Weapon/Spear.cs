using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapons
{
    public InputManager inputManager;
    public bool isThrowed;
    private float throwSpead = 10f;

    float lastAngle;
    private float angle;

    Vector2 lookDir;
    Vector2 mousePos;

    Rigidbody2D rb;
    public Camera mainCamera;


    private void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (!isThrowed)
        {
            transform.position = new Vector2(equippedItemPosition.transform.position.x, equippedItemPosition.transform.position.y);
            inputManager.AttackInputs(this);      
        }
        else
        {
            rb.rotation = lastAngle;

            if (Input.GetMouseButtonDown(1))
            {
                ReturnSpear();
            }
        }

    }

    private void FixedUpdate()
    {

        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

    }
    public override void SpecialAttack()
    {
        lastAngle = angle;
        rb.AddForce(lookDir.normalized * throwSpead, ForceMode2D.Impulse);
        rb.rotation = angle;
        isThrowed = true;
        transform.parent = null;

        GameObject effect = Instantiate(attackEffect, new Vector2(transform.position.x, transform.position.y) + lookDir.normalized * 2, Quaternion.Euler(new Vector3(0, 0, 90 + angle)));
        Destroy(effect, .25f);
    }

    public override void LightAttack()
    {

    }
    public override void HeavyAttack()
    {

    }

    public void ReturnSpear()
    {
        ResetSpear();
    }
    public void ResetSpear()
    {
        rb.velocity = Vector3.zero;
        rb.position = Vector3.zero;
        rb.rotation = 30;
        isThrowed = false;
    }

}
