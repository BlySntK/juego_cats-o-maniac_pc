using UnityEngine;
using System.Collections;

public class ButtonContinuarOptions : MonoBehaviour {

	public void Continuar () {

		Opciones options = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		options.opciones = false;
	}
}
