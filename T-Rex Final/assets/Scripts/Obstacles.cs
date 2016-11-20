using UnityEngine;
using System.Collections;
/// <Obstacles>
/// Kelas ini merupakan kelas untuk membangkitkan obstacle dan pterodactyl
/// dalam permainan T-Rex Runner.
/// </Obstacle>
public class Obstacles : MonoBehaviour {
    /// <challenge>
    /// atribut obstacle dari T-rex game berupa pohon-pohon yang disimpan dalam bentuk array.
    /// </challenge>
	public GameObject[] challenge;

    /// <campos>
    /// Attribute yang berfungsi untuk memberitahu posisi dari kamera
    /// </campos>
	public Transform campos;

    /// <cam>
    /// Attribute yang berfungsi sebagai kamera.
    /// </cam>
    public Camera cam;


    /// <Start>
    ///  Method start berfungsi untuk melakukan inisialisasi pertama pada saat kelas ini dipanggil.
    /// </Start>
    void Start () { 
		ObstacleMaker ();
	}

    /// <Update>
    /// Method update berfungsi untuk menangani kasus-kasus disaat terjadi perubahan frame
    /// pada saat game sedang berjalan.
    /// </Update>
	void Update() {
        DestroyObstacle();
    }

    /// <DestroyObstacle>
    /// method untuk menghancurkan obstacle yang sudah dilewati agar tidak memakan banyak memori.
    /// </DestroyObstacle>
    void DestroyObstacle() {
        transform.Translate(Vector3.right * PlayerPrefs.GetFloat("speed") * Time.deltaTime);
        GameObject cs = GameObject.Find("Quad");
        if (campos.position.x - cs.transform.position.x > 25)
        {
            Destroy(cs);
        }
        
    }

    /// <ObstacleMaker>
    /// Method untuk membuat obstacle untuk dilewati T-rex.
    /// </ObstacleMaker>
    void ObstacleMaker() {
            GameObject clone = (GameObject)Instantiate(challenge[Random.Range(0, challenge.Length)], transform.position, Quaternion.identity);
            clone.name = "Quad";
            clone.AddComponent<BoxCollider2D>();

            clone.GetComponent<BoxCollider2D>().isTrigger = true;
            float xx = Random.Range(1, 5);
            
            Invoke("ObstacleMaker", xx);
	}

}
