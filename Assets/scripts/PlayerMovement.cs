using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private PlayerCollision playerCollision;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollision = GetComponent<PlayerCollision>();
    }

    private void Update()
    {
        if (playerCollision.canMove)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveX, moveY);
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}