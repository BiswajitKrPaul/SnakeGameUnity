using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D gameArea;
    // Start is called before the first frame update

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
        this.transform.position = new Vector3(
        Mathf.Round(Random.Range(gameArea.bounds.min.x, gameArea.bounds.max.x)),
        Mathf.Round(Random.Range(gameArea.bounds.min.y, gameArea.bounds.max.y)),
        0);
    }
}
