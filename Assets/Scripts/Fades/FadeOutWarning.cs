using UnityEngine;
using System.Collections;

public class FadeOutWarning : MonoBehaviour {

	public void Fade () {

		FadeOFFWarning fade = GetComponent<FadeOFFWarning> ();
		if (fade.alpha < 1)
			fade.StartFade (1);
	}

	void Update () {

		FadeOFFWarning fade = GetComponent<FadeOFFWarning> ();
		if (fade.load)
			Application.LoadLevel (1);
	}
}
