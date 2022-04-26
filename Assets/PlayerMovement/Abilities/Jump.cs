using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerInputGet))]
[RequireComponent(typeof(GroundCheck))]
public class Jump : MonoBehaviour
{
    private bool jumpRequest;
    public float maxJump;
    public float jumpSpeed;
    private float maxSpeedChange;
    private bool onGround;
    private int jumpPhase;
    private Vector2 velocity;
    private Rigidbody2D _rigidbody;
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

    }

    // Update is called once per frame
    void Update()
    {
        jumpRequest |= _playerInputGet.GetJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = _groundCheck.IsGrounded();
        velocity = _rigidbody.velocity;
        if (onGround)
        {
            jumpPhase = 0;
        }
        if (jumpRequest)
        {
            jumpRequest = false;
            JumpAction();
        }
        _rigidbody.velocity = velocity;

    }


    private void JumpAction()
    {
        if(onGround || jumpPhase < maxJump)
        {
            jumpPhase++;
            velocity.y = jumpSpeed;
        }
    }
}
