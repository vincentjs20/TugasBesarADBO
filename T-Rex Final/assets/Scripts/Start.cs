using UnityEngine;
using System.Collections;
/// <Start>
/// Kelas yang berfungsi untuk menangani game dimulai pertamakali
/// dan game dimulai setelah gameover / restart game.
/// </Start>
public class Start : MonoBehaviour {
    /// <start>
    /// Attribute yang berfungsi untuk mengetahui 
    /// apakah game sedang berjalan atau tidak.
    /// </start>
	public bool start;

	
    /// <Awake>
    /// Method yang berfungsi untuk membuat game dapat berjalan kembali.
    /// </Awake>
	void Awake () {
		start = false;
	}

    /// <Update>
    /// Method update berfungsi untuk menangani kasus-kasus disaat terjadi perubahan frame
    /// pada saat game sedang berjalan.
    /// </Update>
    void Update () {
        this.createNewGame();
	}

    /// <createNewGame>
    /// Method yang berfungsi untuk menangi game yang dimulai kembali saat TRex telah menabrak
    /// obstacle dan game over.
    /// </createNewGame>
    void createNewGame() {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            start = true;
            Time.timeScale = 1;
            Destroy(this);
        }
    }
}
