using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ballSpawnPoint;
    public GameObject fakeBall; 
    public Rigidbody2D player;
    [SerializeField] private float moveSpeed = 5f;

    private InputAction _moveAction;
    private InputAction _fireAction;
    private BallSpawner _ballSpawner;
    private readonly Vector2 _offScreen = new (-10, -10);
    private bool _isLoaded = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ballSpawner = GameObject.FindGameObjectWithTag("Logic").GetComponent<BallSpawner>();
        _moveAction = InputSystem.actions["Move"];
        _fireAction = InputSystem.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_fireAction.triggered && _isLoaded)
        {
            _isLoaded = false;
            _ballSpawner.FireBall();
            fakeBall.transform.position = _offScreen;
        }
        
        if (_moveAction.inProgress)
        {
            Vector2 movement = _moveAction.ReadValue<Vector2>();
            if (movement.normalized == Vector2.left || movement.normalized == Vector2.right)
            {
                player.position += movement * (moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            player.linearVelocity = Vector2.zero;
        }
    }

    [ContextMenu("ResetFakeBall")]
    public void ResetFakeBall()
    {
        fakeBall.transform.position = ballSpawnPoint.transform.position;
        _isLoaded = true;
    }
    
}
