using UnityEngine;
using System.Collections;

public class Jugar : MonoBehaviour {

	public void Vamos_A_Jugar () {

		Canvas eleccion = GameObject.Find ("Canvas Eleccion").GetComponent<Canvas> ();
		Canvas titulo = GameObject.Find ("Canvas Titulo").GetComponent<Canvas> ();
		eleccion.enabled = true;
		titulo.enabled = false;
	}
}
