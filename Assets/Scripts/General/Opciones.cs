using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Opciones : MonoBehaviour {

	/* Script para la interfaz de opciones, desactivacion/activacion de interfaz de usuario y
	 * la pausa */

	public bool opciones; //Variable con la que se activan las opciones (todo lo demas no rulara)
	public bool pausa; //La pausa tambien inmoviliza al jugador
	Toggle marcarR, marcarT;
	bool currentCasillaR, currentCasillaT, oneSince;
	Canvas ui_opciones, ui_juego, car_text; 
	[HideInInspector]
	public Canvas ui_intro;
	VariablesGlobales vars;



	void Awake () {

		//Al iniciar completamente el juego establecemos las interfaces a falso para que no aparezcan antes de tiempo
		ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
		ui_juego = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();

		//Si estamos en el nivel 1 ocultaremos en un principio la introduccion
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		CargarNuevoNivel deVuelta = GetComponent<CargarNuevoNivel> ();

		/*Si volvemos al nivel 1 (por que nos hayan matado) controlamos que ignoremos
		 *en la primera carga que no hay introduccion pero que la asignemos igualmente
		 */
		if (vars.level == 3 || vars.level == 4 || vars.level == 5 && ui_intro == null) {
			ui_intro = GameObject.Find ("Canvas Intro").GetComponent<Canvas> ();
			ui_intro.enabled = false;
		}

		//Asignaciones de comienzo normales (ocultamos las interfaces
		ui_opciones.enabled = false;
		ui_juego.enabled = false;
	}

	void Update () {

		//Nos ocupamos aqui de ocultar la pantalla de carga una vez se haya cargado el nivel
		CargaScript pantCarga = GameObject.Find ("Pantalla Carga(Clone)").GetComponent<CargaScript> ();
		if (!pantCarga.ocultar)
			pantCarga.ocultar = true;

		//Activar opciones
		if (Input.GetKeyDown (KeyCode.Escape))
			opciones = !opciones;

		//Activar Pausa
		if (Input.GetKeyDown (KeyCode.P))
			pausa = !pausa;

		//Si mostramos las opciones del juego la interfaz de jugador se establecera a falso y se ocultara,
		//no asi con la interfaz de opciones cual se mostrara.
		if (vars.d_easy) {
			if (vars.level == 4) { 
				if (opciones) {
					if (ui_intro != null && !ui_intro.enabled) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
					}
				}else{
					//Siempre que la intro se haya quitado
					if (ui_intro != null && !ui_intro.enabled) {
						//Si no mostramos las opciones la interfaz de usuario se mostrara
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					//En caso contrario...
					}else{
						//Si no mostramos las opciones la interfaz de usuario se mostrara
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}
				}			
			}else if (vars.level == 7) { 
				if (opciones) {
					if (ui_intro == null) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;

					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
					}
				}else{
					//Si no mostramos las opciones la interfaz de usuario se mostrara
					if (ui_intro == null) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}
				}			
			}else if (vars.level == 10) { 
				if (opciones) {
					Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
					ui_normal.enabled = false;
					Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
					ui_opciones.enabled = true;

				}else{
					//Si no mostramos las opciones la interfaz de usuario se mostrara
					Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
					ui_normal.enabled = true;
					Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
					ui_opciones.enabled = false;
					oneSince = false;
				}			
			}
		}else if (vars.d_normal) {
			if (vars.level == 3) { 
				if (opciones) {
					if (ui_intro != null && !ui_intro.enabled) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
					}
				}else{
					//Siempre que la intro se haya quitado
					if (ui_intro != null && !ui_intro.enabled) {
						//Si no mostramos las opciones la interfaz de usuario se mostrara
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
						//En caso contrario...
					}else{
						//Si no mostramos las opciones la interfaz de usuario se mostrara
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}
				}			
			}else if (vars.level == 6) { 
				if (opciones) {
					if (ui_intro == null) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
						
					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
					}
				}else{
					//Si no mostramos las opciones la interfaz de usuario se mostrara
					if (ui_intro == null) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}
				}			
			}else if (vars.level == 9) { 
				if (opciones) {
					Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
					ui_normal.enabled = false;
					Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
					ui_opciones.enabled = true;
					
				}else{
					//Si no mostramos las opciones la interfaz de usuario se mostrara
					Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
					ui_normal.enabled = true;
					Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
					ui_opciones.enabled = false;
					oneSince = false;
				}
			}
		}else if (vars.d_hard) {
			if (vars.level == 5) { 
				if (opciones) {
					if (ui_intro != null && !ui_intro.enabled) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
					}
				}else{
					//Siempre que la intro se haya quitado
					if (ui_intro != null && !ui_intro.enabled) {
						//Si no mostramos las opciones la interfaz de usuario se mostrara
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
						//En caso contrario...
					}else{
						//Si no mostramos las opciones la interfaz de usuario se mostrara
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}
				}			
			}else if (vars.level == 8) { 
				if (opciones) {
					if (ui_intro == null) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
						
					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = true;
					}
				}else{
					//Si no mostramos las opciones la interfaz de usuario se mostrara
					if (ui_intro == null) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}
				}			
			}else if (vars.level == 11) { 
				if (opciones) {
					Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
					ui_normal.enabled = false;
					Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
					ui_opciones.enabled = true;
					car_text.enabled = false;
					
				}else{
					//Si no mostramos las opciones la interfaz de usuario se mostrara
					Canvas car_text = GameObject.Find ("Canvas Car").GetComponent<Canvas> ();
					if (!car_text.enabled) {
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = true;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
						oneSince = false;
					}else{
						Canvas ui_normal = GameObject.Find ("Canvas UI").GetComponent<Canvas> ();
						ui_normal.enabled = false;
						Canvas ui_opciones = GameObject.Find ("Canvas Options").GetComponent<Canvas> ();
						ui_opciones.enabled = false;
					}
				}			
			}

			//La pausa es manejada desde su propio objeto HsacerPausa (que esta en el GameObject Pause)
			if (pausa)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}
}
