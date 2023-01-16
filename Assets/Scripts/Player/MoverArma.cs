using UnityEngine;
using System.Collections;

public class MoverArma : MonoBehaviour {

	void Update () {

		//En caso de hacer pausa, mostrar las opciones principales del juego o la introduccion, el jugador se detendra
		Opciones hacerPausa = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (vars.level == 3 || vars.level == 4 || vars.level == 5) {
			if (!hacerPausa.ui_intro.enabled) {
				if (!hacerPausa.opciones) {
					if (!hacerPausa.pausa) {
						MoverJugador arma = GameObject.Find ("KornRak(Clone)").GetComponent<MoverJugador> ();
						if (arma.raton && !arma.teclado)
							transform.Rotate (Input.GetAxis ("Mouse Y"), 0, 0);
						else if (!arma.raton && arma.teclado)
							transform.Rotate (0, 0, Input.GetAxis ("Vertical"));
					}
				}
			}
		}else if (vars.level > 5 && vars.level < 12) {
			if (!hacerPausa.opciones) {
				if (!hacerPausa.pausa) {
					MoverJugador arma = GameObject.Find ("KornRak(Clone)").GetComponent<MoverJugador> ();
					if (arma.raton && !arma.teclado)
						transform.Rotate (Input.GetAxis ("Mouse Y"), 0, 0);
					else if (!arma.raton && arma.teclado)
						transform.Rotate (0, 0, Input.GetAxis ("Vertical"));
				}
			}
		}
	}
}
