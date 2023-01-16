using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonHard : MonoBehaviour {

	ColorBlock colores;

	public void Hard () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		BotoNormal normal = GameObject.Find ("Boton Normal").GetComponent<BotoNormal> ();
		BotonEasy easy = GameObject.Find ("Boton Facil").GetComponent<BotonEasy> ();
		vars.d_hard = true;
		vars.d_normal = false;
		vars.d_easy = false;
		normal.DeselectNormal ();
		easy.DeselectEasy ();
		Button hard = this.GetComponent<Button> ();
		Color gris = Color.grey;
		colores.normalColor = gris;
		colores.highlightedColor = gris;
		colores.pressedColor = hard.colors.pressedColor;
		colores.disabledColor = hard.colors.disabledColor;
		colores.fadeDuration = 0.8f;
		colores.colorMultiplier = 1;
		hard.colors = colores;
		vars.level = 5;
	}

	public void DeselectHard () {

		Button hard = this.GetComponent<Button> ();
		hard.colors = ColorBlock.defaultColorBlock;
	}
}
