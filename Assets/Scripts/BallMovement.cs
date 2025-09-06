using System.Numerics;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    private Vector2 _direction = new(-1, 1);
    


    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * (ballSpeed * Time.deltaTime));;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.contacts[0].normal;
        _direction = Vector2.Reflect(_direction, direction);
        if (collision.gameObject.name.Contains("Block"))
        {
            Destroy(collision.gameObject);
        }
    }

}
