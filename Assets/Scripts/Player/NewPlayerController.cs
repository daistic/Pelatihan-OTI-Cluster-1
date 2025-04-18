using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody2D rb;

    public float jumpPower;
    public float speed;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        playerControls.Play.Enable();
        playerControls.Play.Jump.performed += Jump;
        playerControls.Play.Move.performed += Move;
    }

    private void OnDestroy()
    {
        playerControls.Play.Jump.performed -= Jump;
    }

    private void Update()
    {
        rb.linearVelocityX = playerControls.Play.Move.ReadValue<float>() * speed;
       
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        rb.linearVelocityY = jumpPower;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<float>());

        rb.linearVelocityX = ctx.ReadValue<float>() * speed;
    }
}
