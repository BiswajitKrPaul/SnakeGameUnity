using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D gameArea;
    // Start is called before the first frame update

    [SerializeField] private Snake snake;

    private void Start()
    {
        RespawnFood();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RespawnFood();
        }
    }

    private void RespawnFood()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(
                    Mathf.Round(Random.Range(gameArea.bounds.min.x, gameArea.bounds.max.x)),
                    Mathf.Round(Random.Range(gameArea.bounds.min.y, gameArea.bounds.max.y)),
                    0);
            if (!SnakeIsAtPosition(spawnPosition))
            {
                this.transform.position = spawnPosition;
                break;
            }
        }

    }


    // Check if the snake is at the given position
    private bool SnakeIsAtPosition(Vector3 position)
    {
        // Loop through each segment of the snake's body
        foreach (Transform segment in snake.segments)
        {
            // If the segment is at the given position, return true
            if (segment.position == position)
            {
                return true;
            }
        }
        // If the snake is not at the given position, return false
        return false;
    }

}
