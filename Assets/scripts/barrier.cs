using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool canMove = true;

    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    private void OnTriggerEnter2D(BoxCollider2D other)
    {
        // Check if the player collided with another object
        if (other.CompareTag("Obstacle"))
        {
            canMove = false;
        }
    }
}
