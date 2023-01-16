using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonEasy : MonoBehaviour {

	ColorBlock colores;

	public void Easy () {
		
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		BotonHard hard = GameObject.Find ("Boton Dificil").GetComponent<BotonHard> ();
		BotoNormal normal = GameObject.Find ("Boton Normal").GetComponent<BotoNormal> ();
		vars.d_hard = false;
		vars.d_normal = false;
		vars.d_easy = true;
		hard.DeselectHard ();
		normal.DeselectNormal ();
		Button easy = this.GetComponent<Button> ();
		Color gris = Color.grey;
		colores.normalColor = gris;
		colores.highlightedColor = gris;
		colores.pressedColor = easy.colors.pressedColor;
		colores.disabledColor = easy.colors.disabledColor;
		colores.colorMultiplier = 1;
		colores.fadeDuration = 0.8f;
		easy.colors = colores;
		vars.level = 4;
	}
	
	public void DeselectEasy () {
		
		Button easy = this.GetComponent<Button> ();
		easy.colors = ColorBlock.defaultColorBlock;
	}
}
