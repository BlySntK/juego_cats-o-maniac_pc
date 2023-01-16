using UnityEngine;
using System.Collections;

public class SonidoMuerte : MonoBehaviour {

	bool bloqueo;
	public bool muerte;

	void Update () {

		AudioSource grito = GetComponent<AudioSource> ();

		if (muerte && !bloqueo) {
			grito.Play ();
			bloqueo = true;
		}

		if (!grito.isPlaying) {
			bloqueo = false;
			muerte = false;
		}
	}
}
