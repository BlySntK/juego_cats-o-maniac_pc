using UnityEngine;
using System.Collections;

public class SonidoSplash : MonoBehaviour {

	bool bloqueo;
	public bool muerte;
	public AudioClip splash;
	
	void Update () {
		
		AudioSource grito = GetComponent<AudioSource> ();
		
		if (muerte && !bloqueo) {
			grito.clip = splash;
			grito.Play ();
			bloqueo = true;
		}
		
		if (!grito.isPlaying) {
			bloqueo = false;
			muerte = false;
		}
	}
}
