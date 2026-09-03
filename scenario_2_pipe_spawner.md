# Skenario 2: Spawner Rintangan & Pipa Bergerak (Obstacle & Random Height)

## 1. Tujuan Skenario (Goal)
Menguji pembuatan rintangan pipa, pergerakan pipa dari kanan ke kiri, variasi ketinggian celah pipa secara acak (*random spawn Y*), dan penghancuran pipa yang keluar layar (*garbage collection*).

---

## 2. Kebutuhan Komponen (Unity Setup)
* **Prefab**: PipePairPrefab
  * Berisi Pipa Atas (TopPipe) & Pipa Bawah (BottomPipe) dengan BoxCollider2D.
  * Celah di antara kedua pipa memiliki lebar tetap yang cukup untuk dilewati Player.
  * Script PipeMovement.cs terpasang pada Prefab.
* **GameObject**: ObstacleSpawner
  * Posisi di luar layar kanan (misal X = 10).
  * Script PipeSpawner.cs.

---

## 3. Alur Pengujian / Test Steps
1. **Spawn Pipa Berkala**:
   * Jalankan game.
   * Amati apakah pipa baru muncul setiap interval waktu tertentu (contoh: tiap 2 detik).
2. **Uji Ketinggian Acak (Random Y)**:
   * Perhatikan posisi vertikal (sumbu Y) dari setiap pipa yang muncul.
   * Pastikan ketinggian celah bervariasi secara acak dalam rentang batas aman (minY sampai maxY), tidak selalu di tengah.
3. **Uji Kecepatan Gerak**:
   * Pipa bergerak lurus ke arah kiri secara stabil dan konsisten.
4. **Uji Destroy Pipa**:
   * Amati tab *Hierarchy* di Unity saat pipa melewati batas kiri layar (misal X < -12).
   * Pastikan GameObject pipa otomatis di-*destroy* dan tidak menumpuk di memori.

---

## 4. Kriteria Keberhasilan (Acceptance Criteria)
* [ ] Pipa ter-spawn secara otomatis dan berulang setiap interval detik tertentu.
* [ ] Posisi Y celah pipa bervariasi secara acak dalam batas aman.
* [ ] Pipa bergerak mulus ke kiri.
* [ ] Pipa otomatis hilang/hancur saat keluar dari layar kiri.
