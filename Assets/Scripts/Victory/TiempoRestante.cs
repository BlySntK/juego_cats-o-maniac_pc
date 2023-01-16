using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TiempoRestante : MonoBehaviour {

	void Update () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		GameObject time = this.gameObject;
		Text texto = time.GetComponent<Text> ();
		texto.text = vars.currentTime.ToString ();
	}
}
