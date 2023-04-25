using UnityEngine;

public class GameBodyDetails
{
    public Transform previousDirection;
    public Transform currentCurrentDirection;
    public GameObject gameObject;


    public GameBodyDetails(Transform prev, Transform curr, GameObject game)
    {
        this.previousDirection = prev;
        this.currentCurrentDirection = curr;
        this.gameObject = game;
    }

}
