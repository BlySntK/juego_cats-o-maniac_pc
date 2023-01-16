using UnityEngine;
using System.Collections;

public class ButtonContinue : MonoBehaviour {

	public void Continuar () {

		VariablesGlobales quitarUI = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		quitarUI.introduccion = false;
	}
}
