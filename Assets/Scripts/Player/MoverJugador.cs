using UnityEngine;
using System.Collections;

public class MoverJugador : MonoBehaviour {
	
	//Declaracion de las variables mas importantes
	CharacterController pavo;
	public bool raton, teclado;
	float speed = 4;
	float gravity = 20;
	float axis;
	EasyLevels guardarPosiciones;
	HardLevels _guardarPosiciones;
	NormalLevels _gargarPosociones_;


	void Start () {

		raton = true;
	}

	void Update () {

		//Agregamos el CharacterController para la movilidad
		pavo = GetComponent<CharacterController> ();

		//En los ejes horizontal y vertical; horizontal para moverse hacia los lados, vertical para adelante/atras
		//En caso de hacer pausa o de mostrar las opciones principales, o se muestre la introduccion, 
		//el jugador se detendra.
		Opciones hacerPausa = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();

		//Depende de la dificultad seleccionada:
		if (vars.d_easy)
			guardarPosiciones = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
		else if (vars.d_hard)
			_guardarPosiciones = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
		else if (vars.d_normal)
			_gargarPosociones_ = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();

		if (vars.level == 3 || vars.level == 4 || vars.level == 5) {
			if (!hacerPausa.ui_intro.enabled) {
				if (!hacerPausa.opciones) {
					if (!hacerPausa.pausa) {
						Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

						//Aplicamos velocidad y una correcta direccion
						movement *= speed;
						movement = transform.TransformDirection (movement);

						//Aplicamos gravedad
						movement.y -= gravity * Time.deltaTime;

						//Rotamos con el raton y finalmente aplicaremos los movimientos
						if (raton) {
							axis = Input.GetAxis ("Mouse X");
							transform.Rotate (0, axis, 0);
						}

						if (teclado) {
							axis = Input.GetAxis ("Horizontal");
							transform.Rotate (0, axis, 0);
						}

						pavo.Move (movement * Time.deltaTime);
					}
				}
			}
		}else if (vars.level > 5 && vars.level < 12) {
			if (!hacerPausa.opciones) {
				if (!hacerPausa.pausa) {
					Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
					
					//Aplicamos velocidad y una correcta direccion
					movement *= speed;
					movement = transform.TransformDirection (movement);
					
					//Aplicamos gravedad
					movement.y -= gravity * Time.deltaTime;
					
					//Rotamos con el raton y finalmente aplicaremos los movimientos
					if (raton) {
						axis = Input.GetAxis ("Mouse X");
						transform.Rotate (0, axis, 0);
					}
					
					if (teclado) {
						axis = Input.GetAxis ("Horizontal");
						transform.Rotate (0, axis, 0);
					}
					
					pavo.Move (movement * Time.deltaTime);

					//Esta linea la usamos para hacer que en el nivel 3 aparezcamos en el mismo lugar donde acabamos 
					//en el segundo
					if (vars.level == 6 || vars.level == 7 || vars.level == 8) {
						Transform lastPosition = this.gameObject.transform;
						vars.posXPlayer = lastPosition.localPosition.x;
						vars.posYPlayer = lastPosition.localPosition.y;
						vars.posZPlayer = lastPosition.localPosition.z;
					}
				}
			}
		}
	}
}
