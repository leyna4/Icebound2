using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("Spawn Timing")]
    public float spawnInterval = 1.5f;

    [Header("Spawn Area")]
    public Vector2 minSpawnPos;
    public Vector2 maxSpawnPos;

    [Header("Spawn Rules")]
    public float minDistanceBetweenEnemies = 1.5f;
    public float minDistanceFromPlayer = 2.5f;
    public int maxTryCount = 15;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = Vector2.zero;
        bool foundValidPosition = false;

        // Güzel pozisyon aramayý dene
        for (int i = 0; i < maxTryCount; i++)
        {
            spawnPos = GetRandomPosition();

            if (IsPositionValid(spawnPos))
            {
                foundValidPosition = true;
                break;
            }
        }

        // Bulamazsan ZORLA SPAWN
        if (!foundValidPosition)
        {
            spawnPos = GetRandomPosition();
        }

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    Vector2 GetRandomPosition()
    {
        float x = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float y = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        return new Vector2(x, y);
    }

    bool IsPositionValid(Vector2 pos)
    {
        if (Vector2.Distance(pos, player.position) < minDistanceFromPlayer)
            return false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(pos, enemy.transform.position) < minDistanceBetweenEnemies)
                return false;
        }

        return true;
    }
}
