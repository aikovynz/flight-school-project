using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Prefab Reference")]
    [Tooltip("Prefab pasangan pipa (PipePair)")]
    public GameObject pipePrefab;

    [Header("Spawn Settings")]
    [Tooltip("Interval waktu antar spawn (detik)")]
    public float spawnInterval = 2f;

    [Tooltip("Batas posisi ketinggian Y minimal pipa")]
    public float minY = -1.8f;

    [Tooltip("Batas posisi ketinggian Y maksimal pipa")]
    public float maxY = 1.8f;

    private float timer = 0f;

    private void Start()
    {
        Debug.Log("[PipeSpawner] Spawner aktif di posisi X: " + transform.position.x);
        SpawnPipe();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        if (pipePrefab == null)
        {
            Debug.LogError("[PipeSpawner] ERROR: 'Pipe Prefab' masih KOSONG (None) di Inspector ObstacleSpawner!");
            return;
        }

        // Tentukan posisi Y secara acak
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        // Munculkan prefab pipa
        GameObject spawned = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        Debug.Log("[PipeSpawner] Berhasil spawn pipa di posisi: " + spawnPosition);
    }
}
