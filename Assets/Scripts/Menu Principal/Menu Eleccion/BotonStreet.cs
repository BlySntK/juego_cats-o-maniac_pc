using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonStreet : MonoBehaviour {

	public Sprite _imgOrigin, _imgSelected;
	Image img;

	public void SelectedScene () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		vars.street = true;
		img = GetComponent<Image> ();
		img.sprite = _imgSelected;
	}

	public void DeslectStrret () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		img = GetComponent<Image> ();
		img.sprite = _imgOrigin;
		vars.street = false;
	}
}
