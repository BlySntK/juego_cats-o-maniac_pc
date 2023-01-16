using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public void Fade () {

		FadeOFF fade = GetComponent<FadeOFF> ();
		if (fade.alpha < 1)
			fade.StartFade (1);
	}

	void Update () {

		FadeOFF fade = GetComponent<FadeOFF> ();
		if (fade.load)
			Application.LoadLevel (2);
	}
}
