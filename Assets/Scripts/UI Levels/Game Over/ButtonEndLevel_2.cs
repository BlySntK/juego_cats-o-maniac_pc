using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonEndLevel_2 : MonoBehaviour {

	public void Salir () {
		
		GameObject quitarLanzador = GameObject.Find ("Lanzador");
		GameObject pantCarga = GameObject.Find ("Pantalla Carga(Clone)");
		Destroy (quitarLanzador);
		Destroy (pantCarga);
		Application.LoadLevel ("Menu");
	}
	
	void Update () {
		
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		if (!over.end) {
			GameObject button = GameObject.Find ("End");
			Image boton = button.GetComponent<Image> ();
			Button _boton = button.GetComponent<Button> ();
			boton.enabled = false;
			_boton.enabled = false;
		}else if (over.end) {
			GameObject button = GameObject.Find ("End");
			Image boton = button.GetComponent<Image> ();
			Button _boton = button.GetComponent<Button> ();
			boton.enabled = true;
			_boton.enabled = true;
		}
	}
}
