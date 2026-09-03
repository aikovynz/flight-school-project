# Task List Prototyping Game "Flight" (W/S Flappy Bird)

Daftar status pengerjaan skenario prototyping inti (Skenario 1 - 4).

---

## ✅ Skenario 1: Player Controller & Movement (W/S)
- [x] Setup GameObject Player (Sprite, Collider2D, Rigidbody2D).
- [x] Script PlayerController.cs (Input W/S, kecepatan vertikal, tilt rotation, boundary clamp 9:16).
- [x] Validasi pergerakan Player responsif dan lancar.

---

## ✅ Skenario 2: Spawner Rintangan & Pipa Bergerak (Random Height)
- [x] Setup Prefab PipePair (Pipa Atas & Bawah, Collider, Tag).
- [x] Script PipeMovement.cs (gerak ke kiri dan auto-destroy saat keluar layar).
- [x] Script PipeSpawner.cs (timer spawn berkala dengan tinggi Y acak).
- [x] Validasi spawn pipa acak dan pergerakan lancar.

---

## ✅ Skenario 3: Sistem Poin & Deteksi Lewat Celah
- [x] Setup trigger ScoreZone di celah pasangan pipa (Is Trigger = true).
- [x] Setup UI Text ScoreText di Canvas HUD.
- [x] Script GameManager.cs (perhitungan skor) & ScoreTrigger.cs.
- [x] Validasi penambahan skor +1 tanpa double-score.

---

## ✅ Skenario 4: Tabrakan, Game Over Panel & Skor Akhir
- [x] Deteksi tabrakan karakter dengan pipa di PlayerController.cs.
- [x] Pembuatan UI GameOverPanel (Title, Final Score, Best Score, Tombol Restart).
- [x] Logika Game Over, penyimpanan High Score (PlayerPrefs), dan reload scene (RestartGame()).
- [x] Validasi alur game lengkap: Start -> Play -> Score -> Game Over -> Restart.
