using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Scroll Settings")]
    [Tooltip("Kecepatan scroll background ke kiri")]
    public float scrollSpeed = 0.5f;

    [Tooltip("Lebar sprite background sebelum di-loop")]
    public float width = 10f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Gerakkan background ke kiri
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Jika sudah bergeser sejauh 'width', kembalikan ke posisi awal secara mulus
        if (transform.position.x <= startPosition.x - width)
        {
            transform.position = startPosition;
        }
    }
}
