using System;
using UnityEngine;

public class TestControl : MonoBehaviour
{
    public float speedModifier;
    public float accelerationModifier;
    public float jumpPower;
    public float jumpDecMod;
    public LayerMask platformLayer;

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    private Vector2 move;
    private bool jump;
    private bool jumpReleased;
    private bool isGrounded;

    private float coyoteTimer = .15f;
    private float coyoteTime = 0;

    private float bufferTimer = .2f;
    private float bufferTime = 0;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        GatherInput();
        calculateTimers();
    }

    private void GatherInput()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        jump = Input.GetKeyDown(KeyCode.UpArrow);
        jumpReleased = !Input.GetKey(KeyCode.UpArrow);
    }

    private void calculateTimers()
    {
        if (isGrounded)
        {
            coyoteTime = 0;
            bufferTimer = 0;
        }

        else
        {
            coyoteTime += Time.deltaTime;
            bufferTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        CheckColliders();

        handleDirections();
        handleJump();

        ApplyMovement();
    }

    private void CheckColliders()
    {
        isGrounded = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0, Vector2.down, 0.05f, platformLayer);
    }

    private void handleDirections()
    {

        if (move.x == 0)
        {
            _rigidbody2D.linearVelocityX = Mathf.MoveTowards(_rigidbody2D.linearVelocityX, 0, Time.fixedDeltaTime * accelerationModifier);
        }

        else
        {
            _rigidbody2D.linearVelocityX = Mathf.MoveTowards(_rigidbody2D.linearVelocityX, move.x * speedModifier, Time.fixedDeltaTime * accelerationModifier);
        }

    }

    private void handleJump()
    {
        if (jump)
        {
            Debug.Log(jump);
        }

        if (jump)
        {
            if (isGrounded || coyoteTime < coyoteTimer || bufferTime > bufferTimer)
            {
                _rigidbody2D.linearVelocityY = jumpPower;
            }
        }

        if (jumpReleased && _rigidbody2D.linearVelocityY > 0)
        {
            _rigidbody2D.linearVelocityY = _rigidbody2D.linearVelocityY / jumpDecMod;
        }


    }

    private void ApplyMovement()
    {

    }
}
