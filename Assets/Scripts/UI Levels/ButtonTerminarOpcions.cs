using UnityEngine;
using System.Collections;

public class ButtonTerminarOpcions : MonoBehaviour {

	public void Terminar () {

		GameObject quitarLanzador = GameObject.Find ("Lanzador");
		GameObject pantCarga = GameObject.Find ("Pantalla Carga(Clone)");
		Destroy (quitarLanzador);
		Destroy (pantCarga);
		Application.LoadLevel ("Menu");
	}
}
