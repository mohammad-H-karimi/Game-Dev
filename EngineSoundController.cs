using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EngineSoundController : MonoBehaviour
{
    public float speed = 10f;
    public float pitchMultiplier = 0.05f;
    private Rigidbody rb;
    private AudioSource engineAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineAudio = GetComponent<AudioSource>();
        engineAudio.loop = true;
        engineAudio.Play();
    }

    void Update()
    {
        // حرکت کاراکتر
        float moveInput = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveInput * speed;
        rb.velocity = move;

        // تنظیم pitch صدا بر اساس سرعت
        float currentSpeed = rb.velocity.magnitude;
        engineAudio.pitch = 1.0f + currentSpeed * pitchMultiplier;
    }
}