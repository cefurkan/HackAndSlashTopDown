using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public bool isThrowed;
    private float throwSpead = 10f;


    private float angle;

    Vector2 lookDir;
    Vector2 mousePos;

    Rigidbody2D rb;
    public Transform equippedItemPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (!isThrowed)
        {
            transform.position = new Vector2(equippedItemPosition.transform.position.x, equippedItemPosition.transform.position.y);

            if (Input.GetMouseButtonDown(1))
            {
                ThrowSpear();
            }
        }
        else
        {
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
    public void ThrowSpear()
    {
        rb.AddForce(lookDir.normalized * throwSpead, ForceMode2D.Impulse);
        rb.rotation = angle;
        rb.AddTorque(100, ForceMode2D.Impulse);
        isThrowed = true;
        transform.parent = null;

    }
    public void ReturnSpear()
    {
        ResetSpear();
    }
    public void ResetSpear()
    {
        rb.velocity = Vector3.zero;
        rb.rotation = 30;
        rb.position = Vector3.zero;
        isThrowed = false;
    }

}
