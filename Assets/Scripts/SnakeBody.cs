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
    [SerializeField] private Sprite rightToDown;
    [SerializeField] private Sprite downToLeft;
    [SerializeField] private Sprite leftToUp;
    [SerializeField] private Sprite upToRight;



    public SnakeBodyDirection direction;
    public SnakeBodyDirection previousDirection;
    public bool isTail;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (direction == SnakeBodyDirection.up && previousDirection == SnakeBodyDirection.up)
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
        else if (direction == SnakeBodyDirection.down && previousDirection == SnakeBodyDirection.down)
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
        else if (direction == SnakeBodyDirection.right && previousDirection == SnakeBodyDirection.right)
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
        else if (direction == SnakeBodyDirection.left && previousDirection == SnakeBodyDirection.left)
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
        else if (direction == SnakeBodyDirection.up && previousDirection == SnakeBodyDirection.left)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailUp;
            }
            else
            {
                spriteRenderer.sprite = leftToUp;
            }
        }
        else if (direction == SnakeBodyDirection.down && previousDirection == SnakeBodyDirection.left)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailDown;
            }
            else
            {
                spriteRenderer.sprite = upToRight;
            }
        }
        else if (direction == SnakeBodyDirection.up && previousDirection == SnakeBodyDirection.right)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailUp;
            }
            else
            {
                spriteRenderer.sprite = downToLeft;
            }
        }
        else if (direction == SnakeBodyDirection.down && previousDirection == SnakeBodyDirection.right)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailDown;
            }
            else
            {
                spriteRenderer.sprite = rightToDown;
            }
        }

        else if (direction == SnakeBodyDirection.left && previousDirection == SnakeBodyDirection.down)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailLeft;
            }
            else
            {
                spriteRenderer.sprite = downToLeft;
            }
        }
        else if (direction == SnakeBodyDirection.right && previousDirection == SnakeBodyDirection.down)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailright;
            }
            else
            {
                spriteRenderer.sprite = leftToUp;
            }
        }


        else if (direction == SnakeBodyDirection.left && previousDirection == SnakeBodyDirection.up)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailLeft;
            }
            else
            {
                spriteRenderer.sprite = rightToDown;
            }
        }
        else if (direction == SnakeBodyDirection.right && previousDirection == SnakeBodyDirection.up)
        {
            if (isTail)
            {
                spriteRenderer.sprite = tailright;
            }
            else
            {
                spriteRenderer.sprite = upToRight;
            }
        }



    }

}
public enum SnakeBodyDirection
{
    up, down, right, left
}
