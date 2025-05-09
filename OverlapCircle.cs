public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 10;
    private Rigidbody2D characterphysic;
    private bool isGrounded = false;

    void Start()
    {
        characterphysic = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.5, 0.2);
        isGrounded = hit != null && hit.CompareTag("Ground");
        float moveX = Input.GetAxis("Horizontal");
        characterphysic.velocity = new Vector2(moveX * moveSpeed, characterphysic.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            characterphysic.velocity = new Vector2(characterphysic.velocity.x, jumpForce);
        }
    }
}