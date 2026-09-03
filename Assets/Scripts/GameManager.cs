using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public bool isGameOver = false;

    [Header("Score Settings")]
    public int score = 0;

    [Header("HUD UI")]
    [Tooltip("Komponen TextMeshProUGUI untuk skor saat bermain")]
    public TextMeshProUGUI scoreText;

    [Header("Game Over UI")]
    [Tooltip("Panel pop-up saat Game Over")]
    public GameObject gameOverPanel;

    [Tooltip("Teks untuk skor akhir di Panel")]
    public TextMeshProUGUI finalScoreText;

    [Tooltip("Teks untuk skor tertinggi (High Score)")]
    public TextMeshProUGUI bestScoreText;

    private const string HIGH_SCORE_KEY = "HighScore";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Pastikan waktu berjalan normal saat mulai/restart
        Time.timeScale = 1f;
        isGameOver = false;
        score = 0;

        // Sembunyikan panel Game Over di awal
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        UpdateScoreUI();
    }

    public void AddScore(int amount = 1)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreUI();
        Debug.Log("[GameManager] Skor bertambah! Skor Sekarang: " + score);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    /// <summary>
    /// Fungsi dipanggil saat Player menabrak rintangan
    /// </summary>
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("[GameManager] GAME OVER dipicu!");

        // 1. Ambil & Simpan High Score ke PlayerPrefs
        int currentHighScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        if (score > currentHighScore)
        {
            currentHighScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentHighScore);
            PlayerPrefs.Save();
        }

        // 2. Update Teks di Game Over Panel
        if (finalScoreText != null)
        {
            finalScoreText.text = score.ToString();
        }

        if (bestScoreText != null)
        {
            bestScoreText.text = currentHighScore.ToString();
        }

        // 3. Sembunyikan skor in-game HUD (opsional) dan Munculkan Game Over Panel
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 4. Hentikan waktu game
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Fungsi untuk tombol Restart
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
