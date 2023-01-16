using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HacerPausa : MonoBehaviour {
	
	void Update () {

		Opciones hacerPausa = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		if (hacerPausa.pausa) {
			Text pausa = this.GetComponent<Text> ();
			pausa.enabled = true;
		}else{
			Text pausa = this.GetComponent<Text> ();
			pausa.enabled = false;
		}
	}
}
