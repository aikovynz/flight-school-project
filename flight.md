# Game Design Document & Brainstorming: Flappy Bird W/S Control ("Flight")

## 1. Ringkasan Konsep (Core Concept)
Game ini mengadopsi mekanisme arcade bergaya **Flappy Bird**, tetapi dengan pembeda utama pada **mekanisme kontrol karakter**:
* **Bukan Flappy Bird biasa**: Di Flappy Bird standar, karakter otomatis jatuh oleh gravitasi konstan dan pemain menekan Space / Tap untuk lompat.
* **Mekanisme Baru**: 
  - Tombol **W** (atau Panah Atas): Karakter bergerak **NAIK**.
  - Tombol **S** (atau Panah Bawah): Karakter bergerak **TURUN**.
  - Kontrol manual aktif ini memberikan tantangan baru dalam menjaga kestabilan posisi karakter di celah pipa.

---

## 2. Fitur Utama & Detail Gameplay

### A. Karakter & Kontrol (Player Controller)
* **Input**:
  - W / Arrow Up: Mendorong karakter ke atas (menggunakan akselerasi halus atau constant vertical velocity).
  - S / Arrow Down: Mendorong karakter ke bawah (menukik lebih cepat).
  - *Feel & Physics*: Karakter memiliki sedikit inersia / momentum dan visual rotasi (tilt up saat naik, tilt down saat turun).
* **Batas Area (Boundary)**:
  - Batas atas layar & batas bawah (tanah/lantai). Jika menabrak batas, pemain langsung Game Over.

### B. Pipa & Spawner Rintangan (Obstacle Spawner)
* **Mekanisme Pipa**:
  - Pasangan pipa atas & bawah dengan celah (gap) di tengah.
  - Pipa bergerak dari kanan ke kiri secara konstan.
* **Random Spawner**:
  - Ketinggian (*Y-offset*) celah pipa di-spawn secara acak dalam batas aman (*min-Y* hingga *max-Y*).
  - Interval waktu antar spawn pipa dapat disesuaikan (misal tiap 1.5 - 2.5 detik).
  - Pipa otomatis dihancurkan (*Destroy*) setelah melewati sisi kiri layar agar hemat memori.

### C. Sistem Skor (Scoring System)
* **Score Trigger**:
  - Di antara pipa atas dan bawah, terdapat trigger area transparan (BoxCollider2D Trigger).
  - Ketika karakter berhasil melewati celah tersebut, skor bertambah +1.
  - Terdapat efek audio SFX poin bertambah.
* **High Score**:
  - Menyimpan skor tertinggi secara lokal menggunakan PlayerPrefs.

### D. Game Over & UI Panel
* **Deteksi Tabrakan (Collision)**:
  - Tabrakan karakter dengan pipa atau batas tanah memicu kondisi **Game Over**.
* **Game Over Panel**:
  - Layar/pergerakan game freeze/pause.
  - Menampilkan panel Game Over berisi:
    - **Current Score** (Skor sesi permainan saat ini)
    - **Best Score / High Score** (Skor tertinggi yang pernah diraih)
    - **Tombol Restart** (Memulai ulang game dari awal / reload scene)
    - **Tombol Main Menu / Quit** (opsional)

---

## 3. Struktur Teknis / Komponen Script (Unity C#)

1. PlayerController.cs:
   - Menangani input W dan S.
   - Mengatur gerakan vertikal Rigidbody2D / Transform.
   - Rotasi dinamis karakter (menghadap ke atas saat naik, menukik saat turun).
   - Deteksi tabrakan (OnCollisionEnter2D / OnTriggerEnter2D).

2. PipeSpawner.cs:
   - Timer countdown untuk spawn prefab pipa.
   - Menghitung posisi Y acak (Random.Range(minY, maxY)).

3. PipeMovement.cs:
   - Menggerakkan prefab pipa ke kiri dengan kecepatan konstan.
   - Menghancurkan diri sendiri jika sudah keluar layar kiri (	ransform.position.x < leftLimit).

4. GameManager.cs:
   - Mengelola state game (*Playing*, *GameOver*).
   - Menghitung skor dan menyimpan *High Score*.
   - Mengaktifkan UI Game Over Panel.
   - Fungsi Restart / Reload Scene.

---

## 4. Ide Brainstorming Tambahan untuk Pengembangan Selanjutnya
* **Tema Visual Karakter**: Pesawat terbang mini, helikopter, roket, burung mecha, atau kapal selam (sangat pas dengan mekanik W/S).
* **Tingkat Kesulitan Dinamis**: Kecepatan pipa makin lama makin cepat bertahap seiring bertambahnya skor.
* **Juiciness / Polish**: Efek partikel asap jet di belakang karakter, animasi mesin, screen shake saat tabrakan, dan SFX/BGM.
