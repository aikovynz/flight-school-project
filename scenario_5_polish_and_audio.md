# Skenario 5: Polishing, Audio SFX, Visual Efek & Dynamic Difficulty

## 1. Tujuan Skenario (Goal)
Meningkatkan kualitas game (*Game Feel & Polish*) dari status prototipe kasar menjadi game yang seru, responsif, dan memuaskan untuk dimainkan. Skenario ini mencakup penambahan Audio SFX (suara mesin, poin, tabrakan), partikel efek asap (Jet Trail), latar belakang bergerak (*Scrolling Background*), dan peningkatan kesulitan dinamis (*Dynamic Difficulty* seiring bertambahnya skor).

---

## 2. Kebutuhan Komponen (Unity Setup)
* **Audio Manager**:
  * GameObject AudioManager dengan AudioSource.
  * Sound Effects (SFX):
    * ScoreSFX: Suara *ding/ping* saat dapat poin.
    * HitSFX: Suara benturan/ledakan saat tabrakan.
    * ButtonSFX: Suara klik tombol restart.
    * BGM (Background Music) santai/arcade.
* **Particle System (Jet Exhaust Trail)**:
  * GameObject anak di belakang Player dengan ParticleSystem (efek asap/api jet).
* **Dynamic Difficulty (Tingkat Kesulitan Dinamis)**:
  * Fitur di PipeSpawner & PipeMovement di mana kecepatan pipa bertambah cepat dan interval spawn semakin rapat secara bertahap seiring bertambahnya skor.
* **Background Parallax / Scrolling**:
  * Gambar latar belakang (awan/langit/kota) yang bergerak perlahan ke kiri untuk memberi ilusi terbang.

---

## 3. Alur Pengujian / Test Steps
1. **Uji Audio SFX & Feedback**:
   * Saat melewati pipa $\rightarrow$ Terdengar suara *ding* poin.
   * Saat menabrak pipa $\rightarrow$ Terdengar suara tabrakan/ledakan.
   * Saat menekan tombol Restart $\rightarrow$ Terdengar suara klik.
2. **Uji Efek Visual (Particle Trail)**:
   * Saat Player bergerak, asap partikel muncul dari ekor pesawat/karakter.
   * Saat tombol W ditekan, partikel asap membesar/lebih deras.
3. **Uji Dynamic Difficulty**:
   * Amati saat skor mencapai kelipatan tertentu (misal: skor 5, 10, 15):
   * Kecepatan gerak pipa meningkat secara halus agar permainan semakin menantang.
4. **Uji Background Scrolling**:
   * Latar belakang bergerak mulus ke kiri dan melakukan looping tanpa jeda/patah.

---

## 4. Kriteria Keberhasilan (Acceptance Criteria)
* [ ] Seluruh aksi penting (skor, hit, klik) memiliki respon suara (SFX) yang pas.
* [ ] Visual efek partikel jet trail aktif dan mengikuti gerak Player.
* [ ] Kesulitan meningkat seiring tingginya skor pemain.
* [ ] Tampilan visual background dinamis dan tidak monoton.
