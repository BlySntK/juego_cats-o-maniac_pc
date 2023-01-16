using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuntuacionOptenida : MonoBehaviour {

	int points = 0;

	void Update () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		GameObject _score = this.gameObject;
		Text texto = _score.GetComponent<Text> ();
		points += vars.puntos;
		texto.text = vars.puntos.ToString ();
	}
}
