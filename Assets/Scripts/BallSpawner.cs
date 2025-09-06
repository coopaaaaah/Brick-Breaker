using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public BallMovement ball;
    public GameObject ballSpawnPosition;

    public void FireBall()
    {
       Instantiate(ball, ballSpawnPosition.transform.position, ballSpawnPosition.transform.rotation);
    }
}
