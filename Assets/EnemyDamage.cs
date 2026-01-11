using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public float damageCooldown = 1f;

    private bool canDamage = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PLAYER'A DEÐDÝ");

        if (other.CompareTag("Player") && canDamage)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                StartCoroutine(DamageCooldown());
            }
        }
    }

    IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
