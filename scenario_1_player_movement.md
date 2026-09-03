# Skenario 1: Player Controller & Kontrol Gerak (W/S)

## 1. Tujuan Skenario (Goal)
Menguji dan memastikan mekanik dasar pergerakan karakter (Player) menggunakan tombol **W** (naik) dan **S** (turun) berjalan dengan lancar, responsif, dan stabil tanpa adanya obstacle terlebih dahulu.

---

## 2. Kebutuhan Komponen (Unity Setup)
* **GameObject**: Player (Sprite 2D).
* **Komponen**:
  * SpriteRenderer (Sprite karakter/pesawat).
  * Rigidbody2D (Body Type: Dynamic / Kinematic; jika Dynamic set gravityScale = 0 atau rendah sesuai kebutuhan).
  * BoxCollider2D atau CircleCollider2D.
  * Script: PlayerController.cs.

---

## 3. Alur Pengujian / Test Steps
1. **Idle State**:
   * Jalankan game (Play Mode).
   * Karakter berada di posisi awal (tengah kiri layar) dalam kondisi stabil / melayang.
2. **Tekan Tombol W (Up)**:
   * Tekan dan tahan tombol W atau Panah Atas.
   * Karakter bergerak ke atas dengan kecepatan konstan/akselerasi halus.
   * Karakter sedikit memiringkan rotasi ke atas (*tilt up*).
3. **Tekan Tombol S (Down)**:
   * Tekan dan tahan tombol S atau Panah Bawah.
   * Karakter bergerak ke bawah dengan kecepatan konstan/akselerasi halus.
   * Karakter sedikit memiringkan rotasi ke bawah (*tilt down*).
4. **Batas Layar (Boundary Check)**:
   * Karakter tidak boleh tembus melewati batas atas atau bawah kamera.

---

## 4. Kriteria Keberhasilan (Acceptance Criteria)
* [ ] Tekan W membuat karakter naik secara konsisten.
* [ ] Tekan S membuat karakter turun secara konsisten.
* [ ] Lepas tombol membuat karakter berhenti naik/turun (atau kembali melayang stabil).
* [ ] Gerakan terasa nyaman (*game feel* pas, tidak terlalu kaku atau terlalu licin).
