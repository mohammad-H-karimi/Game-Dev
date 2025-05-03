using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // اگر کاراکتر 2D هست
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // گرفتن ورودی کاربر
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // مقداردهی انیمیشن
        float speed = movement.sqrMagnitude;
        animator.SetFloat("Speed", speed);
    }

    void FixedUpdate()
    {
        // حرکت دادن فیزیکی کاراکتر
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}