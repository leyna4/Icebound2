using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 3f;
    public float minDistanceBetweenEnemies = 2.5f;
    public float minDistanceFromPlayer = 3.5f;

    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    public Transform player;

    bool canSpawn = true;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (!canSpawn) return;
        if (player == null) return;

        Vector2 spawnPos;
        int tries = 0;

        do
        {
            spawnPos = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            tries++;
            if (tries > 30) return;

        } while (
            Vector2.Distance(spawnPos, player.position) < minDistanceFromPlayer ||
            EnemyTooClose(spawnPos)
        );

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    bool EnemyTooClose(Vector2 pos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(pos, enemy.transform.position) < minDistanceBetweenEnemies)
                return true;
        }
        return false;
    }

    public void StopSpawning()
    {
        canSpawn = false;
        CancelInvoke();
    }
}
