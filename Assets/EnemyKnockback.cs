using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    public void ApplyKnockback(Vector2 hitDirection)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
