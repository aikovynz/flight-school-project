using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Kecepatan pipa bergerak ke kiri")]
    public float moveSpeed = 3f;

    [Tooltip("Batas koordinat X di sisi kiri untuk menghancurkan pipa")]
    public float leftBoundX = -5f;

    private void Update()
    {
        // 1. Gerakkan pipa ke arah kiri secara konstan
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // 2. Hancurkan pipa jika sudah keluar dari layar kiri
        if (transform.position.x < leftBoundX)
        {
            Destroy(gameObject);
        }
    }
}
