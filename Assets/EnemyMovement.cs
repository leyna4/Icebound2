using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Transform player;
    private Rigidbody2D rb;

    [Header("Audio")]
    public AudioClip moveSound;
    public float soundInterval = 1.2f; // Sesler arasý süre

    private AudioSource audioSource;
    private float soundTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        HandleMoveSound();
    }

    [System.Obsolete]
    void HandleMoveSound()
    {
        // Enemy hareket ediyorsa
        if (rb.velocity.magnitude > 0.1f)
        {
            soundTimer -= Time.fixedDeltaTime;

            if (soundTimer <= 0f)
            {
                audioSource.PlayOneShot(moveSound);
                soundTimer = soundInterval;
            }
        }
        else
        {
            soundTimer = 0f;
        }
    }
}
