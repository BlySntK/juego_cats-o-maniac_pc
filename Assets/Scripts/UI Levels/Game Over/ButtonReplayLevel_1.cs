using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonReplayLevel_1 : MonoBehaviour {

	public bool reintento;
	public string level;

	public void ReintentarLevel_1 () {

		reintento = true;
		if (level == "Nivel_1_Normal")
			Application.LoadLevel (level);
		else if (level == "Nivel_1_Easy")
			Application.LoadLevel (level);
		else if (level == "Nivel_1_Hard")
			Application.LoadLevel (level);
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
				GameObject button = GameObject.Find ("ReplayLevel_1");
				Image boton = button.GetComponent<Image> ();
				Button _boton = button.GetComponent<Button> ();
				boton.enabled = false;
				_boton.enabled = false;
			}else if (over.end) {
				GameObject button = GameObject.Find ("ReplayLevel_1");
				Image boton = button.GetComponent<Image> ();
				Button _boton = button.GetComponent<Button> ();
				boton.enabled = true;
				_boton.enabled = true;
			}
		}
	}
}
