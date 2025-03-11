using System;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float airDeceleration;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteCounter = 0;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private bool isGrounded;
    private bool jumpReleased;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        collectInputs();

        if (isGrounded)
        {
            coyoteCounter = 0;
        }
        else
        {
            coyoteCounter += Time.deltaTime;
        }

        _rigidbody.AddForceX(moveSpeed * Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") != 0) {

            animator.SetFloat("speed", Math.Abs(Input.GetAxisRaw("Horizontal")));
            if (Input.GetAxisRaw("Horizontal") < 0) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;

        }

        else animator.SetFloat("speed", Math.Abs(Input.GetAxisRaw("Horizontal")));

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (isGrounded || coyoteCounter < coyoteTime)
            {
                _rigidbody.linearVelocityY = jumpPower;
            }
        }

        if (_rigidbody.linearVelocityY > 0 && jumpReleased)
            _rigidbody.linearVelocityY = _rigidbody.linearVelocityY / airDeceleration;
    }

    private void collectInputs()
    {
        jumpReleased = (Input.GetAxisRaw("Vertical") == 0);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0, Vector2.down, 0.05f, platformLayer);

        
    }
}
