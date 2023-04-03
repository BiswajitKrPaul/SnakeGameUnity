using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private float difficulty = 0.08f;
    private Vector2 direction = Vector2.zero;

    [SerializeField] private Transform bodyPrefab;

    private List<Transform> segments = new List<Transform>();

    private void Start()
    {
        Time.fixedDeltaTime = difficulty;
        ResetGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            GrowBody();

        }
        if (other.tag == "Respawn")
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        direction = Vector2.right;
        transform.position = Vector3.zero;
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(transform);
    }

    private void GrowBody()
    {
        Transform segment = Instantiate(bodyPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }


    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.S) && direction != Vector2.up)
        {
            direction = Vector2.down;
        }

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);

        // transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y, 0);
    }

}
