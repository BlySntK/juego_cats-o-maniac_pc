using UnityEngine;
using System.Collections;

public class CargaScript : MonoBehaviour {

	public bool ocultar; //Variable manejada por Opciones


	void Update () {

		if (ocultar) {
			Canvas imagen = this.GetComponent<Canvas> ();
			imagen.enabled = false;
		}else{
			Canvas imagen = this.GetComponent<Canvas> ();
			imagen.enabled = true;
		}
	}
}
