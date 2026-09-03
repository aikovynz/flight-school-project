using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Tilt Settings")]
    public float maxTiltAngle = 25f;
    public float tiltSmoothSpeed = 8f;

    [Header("Boundary Clamping")]
    public float topBoundary = 4.2f;
    public float bottomBoundary = -4.2f;

    private float verticalInput = 0f;
    private bool isDead = false;

    private void Update()
    {
        if (isDead) return;

        verticalInput = 0f;

        // 1. Cek New Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                verticalInput = 1f;
            }
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                verticalInput = -1f;
            }
        }

        // 2. Cek Legacy Input
        if (Mathf.Approximately(verticalInput, 0f))
        {
            try
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    verticalInput = 1f;
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    verticalInput = -1f;
                }
                else
                {
                    float axis = Input.GetAxisRaw("Vertical");
                    if (Mathf.Abs(axis) > 0.1f)
                    {
                        verticalInput = Mathf.Sign(axis);
                    }
                }
            }
            catch { }
        }

        // 3. Pergerakan Player
        if (verticalInput != 0f)
        {
            transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime, Space.World);
        }

        // 4. Clamping Batas Layar
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, bottomBoundary, topBoundary);
        transform.position = pos;

        // 5. Rotasi Kemiringan
        float targetAngle = verticalInput * maxTiltAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSmoothSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jangan picu Game Over jika yang disentuh adalah ScoreZone
        if (collision.GetComponent<ScoreTrigger>() != null || collision.CompareTag("ScoreZone"))
        {
            return;
        }

        TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("[PlayerController] Karakter menabrak rintangan!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }
    }
}
