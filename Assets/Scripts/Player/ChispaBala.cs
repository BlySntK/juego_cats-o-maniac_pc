using UnityEngine;
using System.Collections;

public class ChispaBala : MonoBehaviour {

	public GameObject chispa;
	public bool chispa_;


	void Update () {

		Disparar disparo = GameObject.Find ("Disparador").GetComponent<Disparar> ();
		if (disparo.disparo && !chispa_) {
			Instantiate (chispa, transform.position, transform.rotation);
			chispa_ = true;
		}else if (!disparo.disparo)
			chispa_ = false;
	}
}
