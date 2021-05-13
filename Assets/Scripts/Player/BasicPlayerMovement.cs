using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public bool lookRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (!lookRight && moveInput.x > 0)
        {
            Flip();
        }
        if (lookRight && moveInput.x < 0)
        {
            Flip();
        }    
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        lookRight = !lookRight;

        /* Vector3 Scaler = transform.localScale;
         Scaler.x *= -1;
         transform.localScale = Scaler;*/
        transform.Rotate(0f, 180f, 0f);
    }
}
