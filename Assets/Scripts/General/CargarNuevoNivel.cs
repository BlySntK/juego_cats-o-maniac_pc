using UnityEngine;
using System.Collections;

public class CargarNuevoNivel : MonoBehaviour {

	public bool cargar, nivel_recargado; 
	bool carga;
	public GameObject pantCarga;
	CargaScript ocultar;

	/* Metodo sobrecargado para una mejor gestion de las diferentes cargas de niveles */

	//Metodo normal de carga entre escenas (desde la 1 a la 3)
	public void Cargar (int level) {

		if (!cargar) {
			Application.LoadLevel (level);
			if (Application.isLoadingLevel) {
				if (!carga) {
					float posX = 362.5f, posY = 204, posZ = 0;
					Vector3 posicion = new Vector3 (posX, posY, posZ);
					ocultar = GameObject.Find ("Pantalla Carga(Clone)").GetComponent<CargaScript> ();
					ocultar.ocultar = false;
					carga = true;
					cargar = true;
				}
			}
		}
	}

	//Metodo encargado de cargar solo el reinicio, de la 2 a la 1 y la 3 a la 1
	public void Cargar (string level) {
		
		if (!cargar) {
			Application.LoadLevel (level);
			if (Application.isLoadingLevel) {
				if (!carga) {
					float posX = 362.5f, posY = 204, posZ = 0;
					Vector3 posicion = new Vector3 (posX, posY, posZ);
					VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
					ocultar = GameObject.Find ("Pantalla Carga(Clone)").GetComponent<CargaScript> ();
					ocultar.ocultar = false;
					carga = true;
					nivel_recargado = true;
					vars.carga_completa = nivel_recargado;
					cargar = true;
				}
			}
		}
	}
}
