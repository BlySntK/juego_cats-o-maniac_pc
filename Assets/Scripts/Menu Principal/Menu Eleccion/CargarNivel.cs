using UnityEngine;
using System.Collections;

public class CargarNivel : MonoBehaviour {

	[HideInInspector]
	public bool carga;
	[HideInInspector]
	public bool cargar;
	public GameObject pantCarga;
	[HideInInspector]
	VariablesGlobales vars;

	void Update () {

		vars = GetComponent<VariablesGlobales> ();
		if (cargar) {
			if (vars.street && vars.d_normal) {
				Application.LoadLevel ("Nivel_1_Normal"); //3
				if (Application.isLoadingLevel) {
					if (!carga) {
						float posX = 362.5f, posY = 204, posZ = 0;
						Vector3 posicion = new Vector3 (posX, posY, posZ);
						Instantiate (pantCarga, posicion, transform.rotation);
						carga = true;
						cargar = false;
						Destroy (this);
					}
				}
			}else if (vars.street && vars.d_easy) {
				Application.LoadLevel ("Nivel_1_Easy"); //4
				if (Application.isLoadingLevel) {
					if (!carga) {
						float posX = 362.5f, posY = 204, posZ = 0;
						Vector3 posicion = new Vector3 (posX, posY, posZ);
						Instantiate (pantCarga, posicion, transform.rotation);
						carga = true;
						cargar = false;
						Destroy (this);
					}
				}
			}else if (vars.street && vars.d_hard) {
				Application.LoadLevel ("Nivel_1_Hard"); //5
				if (Application.isLoadingLevel) {
					if (!carga) {
						float posX = 362.5f, posY = 204, posZ = 0;
						Vector3 posicion = new Vector3 (posX, posY, posZ);
						Instantiate (pantCarga, posicion, transform.rotation);
						carga = true;
						cargar = false;
						Destroy (this);
					}
				}
			}
		}
	}
}
