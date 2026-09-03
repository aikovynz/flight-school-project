using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[ScoreTrigger] Sesuatu menyentuh trigger skor: " + collision.gameObject.name);

        if (!hasScored)
        {
            // Cek apakah yang menyentuh adalah Player (via nama, tag, atau script PlayerController)
            bool isPlayer = collision.gameObject.name.Contains("Player") 
                            || collision.CompareTag("Player") 
                            || collision.GetComponent<PlayerController>() != null 
                            || collision.GetComponentInParent<PlayerController>() != null;

            if (isPlayer)
            {
                hasScored = true;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.AddScore(1);
                }
                else
                {
                    Debug.LogError("[ScoreTrigger] ERROR: GameManager.Instance bernilai NULL! Pastikan GameObject GameManager ada di scene dan script GameManager terpasang.");
                }
            }
        }
    }
}
