using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerInputGet))]
[RequireComponent(typeof(GroundCheck))]
public class Move : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float airAcceleration;
    private float maxSpeedChange;
    private Vector2 desDirection;
    private Vector2 desSpeed;
    private Vector2 velocity;
    private Rigidbody2D _rigidbody;
    private Jump _jump;
    private BoxCollider2D _boxCollider;
    private PlayerInputGet _playerInputGet;
    private GroundCheck _groundCheck;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerInputGet = GetComponent<PlayerInputGet>();
        _groundCheck = GetComponent<GroundCheck>();
        _jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        desDirection.x = _playerInputGet.GetMoveInput();
        desSpeed = new Vector2(maxSpeed * desDirection.x, 0f);
    }

    private void FixedUpdate()
    {
        velocity = _rigidbody.velocity;
        if (desSpeed.x == 0 && velocity.x == 0 && velocity.y == 0) { return; }
        if (_groundCheck.IsGrounded())
        {
            maxSpeedChange = acceleration * Time.deltaTime;
            _jump.setJumpPhase(0);
        }
        else
        {
            _jump.setJumpPhase(1);
            maxSpeedChange = airAcceleration * Time.deltaTime;
        }
        velocity.x = Mathf.MoveTowards(velocity.x, desSpeed.x, maxSpeedChange);
        _rigidbody.velocity = velocity;
    }
}
