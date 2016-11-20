using UnityEngine;
using System.Collections;
/// <Background>
/// Kelas BGShift berfungsi untuk menangani pergerakan background agar
/// background mengeikut pergerakan kamera pada saat game berjalan.
/// </Bacground>
public class Background: MonoBehaviour {
    

        /// <onTriggerExit2D>
        /// Method ini berfungsi untuk menangani perpihanan background agar
        /// mengikuti pergerakan kamera, dengan cara melakukan perturakan
        /// background dengan tujuan untuk menghemat penggunaan memori.
        /// </onTriggerExit2D>

	void OnTriggerExit2D(Collider2D collider){
		float width = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		pos.x += width * 1.95f;
		if(collider.gameObject.tag=="BG")
		collider.transform.position = pos;

		if (collider.gameObject.tag == "BG2")
			collider.transform.position = pos;
	}
}

