using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotoNormal : MonoBehaviour {

	ColorBlock colores;

	public void Normal () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		BotonHard hard = GameObject.Find ("Boton Dificil").GetComponent<BotonHard> ();
		BotonEasy easy = GameObject.Find ("Boton Facil").GetComponent<BotonEasy> ();
		vars.d_hard = false;
		vars.d_normal = true;
		vars.d_easy = false;
		hard.DeselectHard ();
		easy.DeselectEasy ();
		Button normal = this.GetComponent<Button> ();
		Color gris = Color.grey;
		colores.normalColor = gris;
		colores.highlightedColor = gris;
		colores.pressedColor = normal.colors.pressedColor;
		colores.disabledColor = normal.colors.disabledColor;
		colores.fadeDuration = 0.8f;
		colores.colorMultiplier = 1;
		normal.colors = colores;
		vars.level = 3;
	}

	public void DeselectNormal () {
		
		Button normal = this.GetComponent<Button> ();
		normal.colors = ColorBlock.defaultColorBlock;
	}
}
