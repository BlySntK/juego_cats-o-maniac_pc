using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonHecho : MonoBehaviour {

	bool carga, botonPulsado;
	ColorBlock colores;

	public void CargarNivel () {

		CargarNivel on = GameObject.Find ("Lanzador").GetComponent<CargarNivel> ();
		VariablesGlobales vars = on.GetComponent<VariablesGlobales> ();
		if (vars.d_easy || vars.d_normal || vars.d_hard) {
			if (vars.street) {
				Button botonHecho = this.GetComponent<Button> ();
				Color gris = Color.grey;
				colores.normalColor = gris;
				colores.highlightedColor = gris;
				colores.pressedColor = botonHecho.colors.pressedColor;
				colores.disabledColor = botonHecho.colors.disabledColor;
				colores.fadeDuration = 0.8f;
				colores.colorMultiplier = 1;
				botonHecho.colors = colores;
				botonPulsado = true;
		


				if (botonPulsado) {
					carga = true;
					on.cargar = carga;
					vars.introduccion = true;
				}
			}
		}
	}
}
