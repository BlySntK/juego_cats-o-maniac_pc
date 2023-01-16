using UnityEngine;
using System.Collections;

public class BackCredits : MonoBehaviour {

	void OnTriggerEnter (Collider it) {

		if (it.gameObject.name == "KornRakMenu(Clone)") {
			InstanciaKornMenu korn = GameObject.Find ("Posicion Inicial").GetComponent<InstanciaKornMenu> ();
			korn.instancia = false;
		}
	}
}
