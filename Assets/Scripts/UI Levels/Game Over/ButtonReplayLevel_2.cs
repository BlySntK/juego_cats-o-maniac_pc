using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonReplayLevel_2 : MonoBehaviour {

	public bool reintento;
	public string level;

	public void ReintentarLevel_2 () {

		CargarNuevoNivel carga = GameObject.Find ("JuegoGeneral").GetComponent<CargarNuevoNivel> ();
		reintento = true;
		if (level == "Nivel_1_Normal") {
			carga.cargar = false;
			carga.Cargar (level);
		}else if (level == "Nivel_1_Easy") {
			carga.cargar = false;
			carga.Cargar (level);
		}else if (level == "Nivel_1_Hard") {
			carga.cargar = false;
			carga.Cargar (level);
		}
	}

	void Update () {
		
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		if (reintento) {
			if (over.end) {
				over.end = false;
				reintento = false;
			}
		}else{
			if (!over.end) {
				GameObject button = GameObject.Find ("ReplayLevel_2");
				Image boton = button.GetComponent<Image> ();
				Button _boton = button.GetComponent<Button> ();
				boton.enabled = false;
				_boton.enabled = false;
			}else if (over.end) {
				GameObject button = GameObject.Find ("ReplayLevel_2");
				Image boton = button.GetComponent<Image> ();
				Button _boton = button.GetComponent<Button> ();
				boton.enabled = true;
				_boton.enabled = true;
			}
		}
	}
}
