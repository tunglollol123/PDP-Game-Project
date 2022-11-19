using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public BoxCollider2D collision;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isRight = true;
    private bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(collision.bounds.center, collision.bounds.size, 0f, Vector2.down, extraHeight,groundLayer);
        return raycastHit2D.collider != null;
    }

    void Update()
    {
        if (!isRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
