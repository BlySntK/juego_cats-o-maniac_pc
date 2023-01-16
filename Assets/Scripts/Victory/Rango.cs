using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rango : MonoBehaviour {

	void Update () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		GameObject grado = this.gameObject;
		Text texto = grado.GetComponent<Text> ();

		if (vars.d_easy && vars.puntos > 10000 && vars.currentTime > 20)
			texto.text = "A";
		else if (vars.d_easy && vars.puntos > 5000 && vars.puntos < 6000 && vars.currentTime > 20)
			texto.text = "B";
		else if (vars.d_easy && vars.puntos > 800 && vars.puntos < 2000 && vars.currentTime > 20)
			texto.text = "C";
		else if (vars.d_normal && vars.puntos > 2500 && vars.puntos < 3000 && vars.currentTime > 40)
			texto.text = "A";
		else if (vars.d_normal && vars.puntos > 2000 && vars.puntos < 2100 && vars.currentTime > 40)
			texto.text = "B";
		else if (vars.d_normal && vars.puntos > 1450 && vars.puntos < 1990 && vars.currentTime > 40)
			texto.text = "C";
		else if (vars.d_hard && vars.puntos > 2050 && vars.puntos < 2200 && vars.currentTime > 10)
			texto.text = "A";
		else if (vars.d_hard && vars.puntos > 1550 && vars.puntos < 2000 && vars.currentTime > 10)
			texto.text = "B";
		else if (vars.d_hard && vars.puntos > 1250 && vars.puntos < 1500 && vars.currentTime > 10)
			texto.text = "C";
	}
}
