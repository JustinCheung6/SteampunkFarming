using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float deceleration = 1f;

    private float carryOverMod = 0f;

    private Rigidbody2D rb = null;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        //This is to minimize division in calculations
        carryOverMod = 1f / deceleration;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float maxDirection = Mathf.Abs(Mathf.Abs(movement.x) > Mathf.Abs(movement.y) ? movement.x : movement.y);

        //Defualt Case: full speed movement
        movement = movement.normalized * speed * maxDirection;

        //X Script
        //Case not moving / Case switching directions: Decelerate
        if ((movement.x == 0 || Mathf.Sign(movement.x) != Mathf.Sign(rb.velocity.x)) && rb.velocity.x != 0)
        {
            //Case switching direction & decel past 0: Carry Over to Acceleration (proportional carry over)
            if (Mathf.Sign(movement.x) != Mathf.Sign(rb.velocity.x) && Mathf.Abs(rb.velocity.x) < deceleration)
                movement.x *= carryOverMod;
            else
                movement.x = Mathf.MoveTowards(rb.velocity.x, 0f, deceleration);
        }

        //Y Script
        //Case not moving / Case switching directions: Decelerate
        if ((movement.y == 0 || Mathf.Sign(movement.y) != Mathf.Sign(rb.velocity.y)) && rb.velocity.y != 0)
        {
            //Case switching direction & decel past 0: Carry Over to Acceleration (proportional carry over)
            if (Mathf.Sign(movement.y) != Mathf.Sign(rb.velocity.y) && Mathf.Abs(rb.velocity.y) < deceleration)
                movement.y *= carryOverMod;
            else
                movement.y = Mathf.MoveTowards(rb.velocity.y, 0f, deceleration);
        }

        rb.velocity = movement;
    }
}
