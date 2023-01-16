using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cats : MonoBehaviour {

	void Update () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		GameObject n_cat = this.gameObject;
		Text texto = n_cat.GetComponent<Text> ();
		texto.text = vars.n_cats.ToString ();
	}
}
