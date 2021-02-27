using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapons
{
    public bool isThrowed;
    private float throwSpead = 10f;
    float lastAngle;

    PlayerController player;
    Rigidbody2D rb;

    private void Start()
    {
        player = GameManager.manager.player;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isThrowed)
        {
            transform.position = new Vector2(equippedItemPosition.transform.position.x, equippedItemPosition.transform.position.y);
            player.AttackInputs(this);      
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
    public override void SpecialAttack()
    {
        lastAngle = player.angle;
        rb.AddForce(player.lookDir.normalized * throwSpead, ForceMode2D.Impulse);
        rb.rotation = player.angle;
        isThrowed = true;
        transform.parent = null;

        GameObject effect = Instantiate(attackEffect, new Vector2(transform.position.x, transform.position.y) + GameManager.manager.player.lookDir.normalized * 2, Quaternion.Euler(new Vector3(0, 0, 90 + player.angle)));
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
        transform.SetParent(GameManager.manager.player.transform);
        rb.velocity = Vector3.zero;
        rb.position = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0,0,30);
        isThrowed = false;
    }

}
