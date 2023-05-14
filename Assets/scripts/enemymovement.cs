using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxY = 5f; // Maximum Y position
    public float minY = -5f; // Minimum Y position

    public Transform player; // Reference to the player's transform
    public float fieldOfViewAngle = 90f; // Field of view angle in degrees
    public float sightDistance = 10f; // Maximum sight distance

    private bool movingUp = true;
    private bool playerDetected = false;

    private void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveEnemy());
    }

    private void Update()
    {
        if (playerDetected)
        {
            // Stop the game or trigger game over logic here
            // For example, you can call a GameOver function or show a game over screen
            StopGame();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the player is within the enemy's line of sight
        if (other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            float distance = direction.magnitude;

            // Check if the player is within the sight distance
            if (distance <= sightDistance)
            {
                // Check if the player is within the field of view angle
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle < fieldOfViewAngle * 0.5f)
                {
                    playerDetected = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the enemy's line of sight trigger
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }

    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            // Move the enemy up
            if (movingUp)
            {
                while (transform.position.y < maxY)
                {
                    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                    yield return null;
                }
                movingUp = false;
            }
            // Move the enemy down
            else
            {
                while (transform.position.y > minY)
                {
                    transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
                    yield return null;
                }
                movingUp = true;
            }

            yield return null;
        }
    }

    private void StopGame()
    {
        // Implement your game over logic here
        // For example, pause the game, show a game over screen, or reset the level
        Time.timeScale = 0f; // Stop time to pause the game
    }
}