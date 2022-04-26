using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float patrolSpeed;
    private int moveDirection = 0;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Vector2 velocity;
    float trans1;
    float trans2;
    private void Awake()
    {
        trans1 = point1.transform.position.x;
        trans2 = point2.transform.position.x;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void FixedUpdate()
    {
        switch (moveDirection)
        {
            case 0://left
                velocity.x = -patrolSpeed;
                _rigidbody.velocity = velocity;
                if(transform.position.x < trans1) { moveDirection = 1; _spriteRenderer.flipX = false; };
                break;
            case 1://right
                velocity.x = patrolSpeed;
                _rigidbody.velocity = velocity;
                if (transform.position.x > trans2) { moveDirection = 0; _spriteRenderer.flipX = true; };
                break;
        }
    }


    // Start is called before the first frame update
}
