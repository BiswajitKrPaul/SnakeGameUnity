using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite horizontal;
    [SerializeField] private Sprite vertical;

    [SerializeField] private Sprite tailright;
    [SerializeField] private Sprite tailLeft;
    [SerializeField] private Sprite tailUp;
    [SerializeField] private Sprite tailDown;

    public SnakeBodyDirection direction;
    public bool isTail;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (direction == SnakeBodyDirection.up)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailUp;
            }
            else
            {
                spriteRenderer.sprite = vertical;
            }
        }
        else if (direction == SnakeBodyDirection.down)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailDown;
            }
            else
            {
                spriteRenderer.sprite = vertical;
            }
        }
        else if (direction == SnakeBodyDirection.right)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailright;
            }
            else
            {
                spriteRenderer.sprite = horizontal;
            }
        }
        else if (direction == SnakeBodyDirection.left)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailLeft;
            }
            else
            {
                spriteRenderer.sprite = horizontal;
            }
        }
    }

}
public enum SnakeBodyDirection
{
    up, down, right, left
}
