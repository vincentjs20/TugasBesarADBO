using UnityEngine;
using System.Collections;
/// <GameOver>
/// Kelas yang berfungsi untuk menangani kasus saat game berakhir.
/// </GameOver>
public class GameOver : MonoBehaviour {

    /// <gameOver>
    /// Attribute yang menangani jika TRex telah melewati obstacle.
    /// </gameOver>
	public bool gameOver;

    /// <ob>
    /// Attribute yang menangani
    /// </ob>
	public Start ob;

    /// <styleScreen>
    /// Attribute yang berfungsi untuk menangai style gambar.
    /// </styleScreen>
	public GUIStyle styleScreen;

    /// <image1>
    /// Attribute yang berfungsi untuk menyimpan gambar.
    /// </image1>
	public Texture image1;

    /// <audiOver>
    /// Attribute yang berfungsi untuk menyimpan suara.
    /// </audiOver>
	public AudioSource[] audiOver;

    /// <summary>
    /// Method start berfungsi untuk melakukan inisialisasi pertama pada saat game dimulai.
    /// </summary>
    void Start () {
		gameOver = false;

		Time.timeScale = 0;
		audiOver = GetComponents<AudioSource>();
		
	}
	
	/// <summary>
    /// Method yang berfungsi untuk menangani kasus dimana TRex menabrak
    /// obstacle.
    /// </summary>
    /// <param Collider2D="collider"></param>

	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.name == "Quad") {
			Time.timeScale=0;
			gameOver=true;
			AudioSource audiOver1=audiOver[1];
			audiOver1.Play ();
		}
}
    /// <OnGUI>
    /// Method yang berfungsi untuk menampilkan score ke layar.
    /// </OnGUI>
	void OnGUI(){
		if (gameOver) {
			GUI.Label(new Rect(Screen.width*0.3f,Screen.height*0.45f,Screen.width*0.75f,Screen.height*0.25f),"Game Over!",styleScreen);
			if(GUI.Button(new Rect(Screen.width*0.48f,Screen.height*0.55f, 50, 50), image1)){

				Application.LoadLevel("Scene1");
				Time.timeScale=1;
			}
		}
		if (!ob.start) {
			GUI.Label(new Rect(Screen.width*0.3f,Screen.height*0.45f,Screen.width*0.75f,Screen.height*0.25f),"Tap Anywhere!",styleScreen);
		}
	}
}
