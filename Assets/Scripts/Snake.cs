using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;

    [SerializeField] private Transform bodyPrefab;

    private SpriteRenderer spriteRenderer;

    public Sprite headUp;
    public Sprite headDown;
    public Sprite headLeft;
    public Sprite headRight;


    public Sprite horizontalBody;
    public Sprite verticalBody;

    public List<Transform> segments = new List<Transform>();

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.sprite = headRight;
        transform.position = Vector3.zero;
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(transform);
        Transform snakeTail = Instantiate(bodyPrefab);
        snakeTail.position = new Vector2(transform.position.x - 1, transform.position.y);
        snakeTail.GetComponent<SnakeBody>().direction = getDirection(direction);
        snakeTail.GetComponent<SnakeBody>().isTail = true;
        segments.Add(snakeTail);
    }

    private void GrowBody()
    {
        Transform segment = Instantiate(bodyPrefab);
        segment.position = segments[segments.Count - 2].position;
        if (segments.Count - 2 == 0)
        {
            segment.GetComponent<SnakeBody>().direction = getDirection(direction);
        }
        else
        {
            segment.GetComponent<SnakeBody>().direction = segments[segments.Count - 2].GetComponent<SnakeBody>().direction;
        }
        segments.Insert(segments.Count - 1, segment);
    }

    private SnakeBodyDirection getDirection(Vector2 direction)
    {
        if (direction == Vector2.up) return SnakeBodyDirection.up;
        else if (direction == Vector2.down) return SnakeBodyDirection.down;
        if (direction == Vector2.left) return SnakeBodyDirection.left;
        else if (direction == Vector2.right) return SnakeBodyDirection.right;

        return SnakeBodyDirection.right;
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) && direction != Vector2.down)
        {
            direction = Vector2.up;
            spriteRenderer.sprite = headUp;
        }
        else if (Input.GetKey(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
            spriteRenderer.sprite = headLeft;
        }
        else if (Input.GetKey(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
            spriteRenderer.sprite = headRight;
        }
        else if (Input.GetKey(KeyCode.S) && direction != Vector2.up)
        {
            direction = Vector2.down;
            spriteRenderer.sprite = headDown;
        }

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
            if (i - 1 == 0)
            {
                segments[i].GetComponent<SnakeBody>().direction = getDirection(direction);
            }
            else
            {
                segments[i].GetComponent<SnakeBody>().direction = segments[i - 1].GetComponent<SnakeBody>().direction;
            }

        }
        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);

        // transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y, 0);
    }

}
