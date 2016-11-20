using UnityEngine;
using System.Collections;
/// <Camera>
/// Kelas CamRunner berfungsi untuk membuat camera bergerak maju secara
/// terus menerus hingga game berakhir.
/// </Camera>
public class Camera: MonoBehaviour {

    /// <Box>
    /// Attribute yang berfungsi untuk menyimpan nilai box.
    /// </Box>
	public Transform Box;

    /// <style>
    /// Attribute yang berfungsi untuk menangani GUI
    /// </style>
	public GUIStyle style;

    /// <scoreCounter>
    /// Attribute scoreCounter berfungsi untuk menaikan score pemain
    /// seiring dengan pergerakan TRex
    /// </scoreCounter>
	public float scoreCounter=0.0f;

    /// <score>
    /// Attribute score berfungsi untuk menyimpan score pemain.
    /// </score>
	public int score;

    /// <highScore>
    /// Attribute hi berfungsi untuk menyimpan score tertinggi.
    /// </highScore>
	public int highScore;

    /// <summary>
    /// 
    /// </summary>
    public float speed = 7f;

    /// <audi100>
    /// Attribute audi100 berfungsi untuk menyimpan suara.
    /// </audi100>
	public AudioSource audi100;

    /// <Start>
    /// Method start berfungsi untuk melakukan inisialisasi pertama pada saat kelas ini dipanggil.
    /// </Start>
    void Start () {
		PlayerPrefs.SetFloat("speed",7);
		highScore = PlayerPrefs.GetInt ("high",0);
		audi100=GetComponent<AudioSource>();
		score = 0;
	}

    /// <Update>
    /// Method update berfungsi untuk menangani kasus-kasus disaat terjadi perubahan frame
    /// pada saat game sedang berjalan.
    /// </Update>
    void Update () {
        GetHighScore();
        if (score % 100 == 0 && score != 0)
        {
            this.speed = this.speed + 0.1f;
            PlayerPrefs.SetFloat("speed", this.speed);

        }
    }
    

    /// <onGUI>
    /// Method yang berfungsi untuk mengeluarkan highscore dan score ke layar.
    /// </onGUI>
	void OnGUI(){

		string high = highScore.ToString ();
		string scoreString = score.ToString();
		GUI.Label (new Rect(Screen.width*0.8f,Screen.height*0.07f,Screen.width*0.2f,Screen.height*0.05f),scoreString,style);
		GUI.Label (new Rect(Screen.width*0.65f,Screen.height*0.07f,Screen.width*0.2f,Screen.height*0.05f),"HI  "+high,style);
	}

    /// <getHighScore>
    /// method untuk menentukan score dan highscore.
    /// </getHighScore>
    void GetHighScore()
    {
        transform.Translate(Vector3.right * PlayerPrefs.GetFloat("speed") * Time.deltaTime);
        Box.Translate(Vector3.right * PlayerPrefs.GetFloat("speed") * Time.deltaTime);
        scoreCounter += Time.deltaTime * 10;

        this.score = (int)scoreCounter;
        if (highScore < score)
        {
            PlayerPrefs.SetInt("high", score);
            PlayerPrefs.Save();
        }
        if (score % 100 == 0 && score != 0)
        {
            audi100.Play();
        }
    }
}
