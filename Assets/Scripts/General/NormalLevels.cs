using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NormalLevels : MonoBehaviour{
	
	/* Motor principal de los niveles de dificultad normal */

	VariablesGlobales vars;
	Temporizador tempoMuertes;
	GameOver over;
	public long n_cats = 0; //Variable que decidira si hay Game Over o no, es manejada por el objeto Catkill
	float timeWait = 3, alpha_, speed = 1.5f;
	public long maxCatsKills;
	bool tiempoAsignado, pulsado, bloqueo, unaVez, respawneado; 
	[HideInInspector]
	public bool _disparo;
	int contadorDisparos;
	RespawnPlayer respawn_player;
	Recargar noRecargar;
	Camera camaraPatroll_1, camaraPatroll_2;



	void Awake () {

		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		tempoMuertes = GameObject.Find ("Timer").GetComponent<Temporizador> ();
		over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		respawn_player = GameObject.Find ("RespawnPlayer").GetComponent<RespawnPlayer> ();
	}

	void Update () {

		//Este script gestiona todo lo relacionado con el nivel callejero en la dificultad normal. Asi como
		//a traves de este script tambien controlamos el texto que avisa del siguiente nivel por pantalla,
		//tanto si se muestra como si no.
		if (vars.d_normal && vars.level == 3 && vars.street) {

			//Si no hay game over, se procesara el nivel
			if (!over.end) {
				//Le asignamos el nuevo tiempo limite y hacemos un respawn del jugador
				respawn_player = GameObject.Find ("RespawnPlayer").GetComponent<RespawnPlayer> ();
				Opciones GestionIntro = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
				Camera camaraPatroll_1 = GameObject.Find ("PatrollCamera").GetComponent<Camera> ();
				Camera camaraPatroll_2 = GameObject.Find ("PatrollCamera_lvl2").GetComponent<Camera> ();
				camaraPatroll_1.enabled = false;
				camaraPatroll_2.enabled = false;
				if (!tiempoAsignado) {
					tempoMuertes.timeLeft = 45;

					//Controlamos que hasta que no quitemos la Introduccion, no empezara a descontar el tiempo
					//ademas de asegurarnos un buen reinicio del juego en caso de matarnos.
					if (vars.introduccion) {
						GestionIntro.ui_intro.enabled = true;
						tempoMuertes.begingCountdown = false;

						//Para que no se dispare el arma mientras vemos la introduccion
						_disparo = true;
					}else{
						GestionIntro.ui_intro.enabled = false;
						tempoMuertes.begingCountdown = true;
						vars.carga_completa = false;
						_disparo = false;
						unaVez = false;
						tiempoAsignado = true;
					}
				}

				//Le damos al jugador las coordenadas donde aparecer en el inicio del juego
				respawn_player.posX = 18; respawn_player.posY = -1.22f; respawn_player.posZ = -104.41f;
				respawn_player.respawnPlayer = true;
				if (respawn_player.player == 1)
					noRecargar = GameObject.Find ("Disparador").GetComponent<Recargar> ();


				//Gatos minimas a reventar:
				maxCatsKills = 70;
				CatKill objetivos = GameObject.Find ("Kills").GetComponent<CatKill> ();
				objetivos.Targets (maxCatsKills);

				//Comporobamos, en todo momento, la cantidad de gatos muertos. Antes de que el tiempo
				//se agote, pasaremos de nivel... o no.
				if (n_cats >= maxCatsKills && tempoMuertes.timeLeft >= 0) {
					GameObject nextLevel = GameObject.Find ("Next Level");
					Text texto = nextLevel.GetComponent<Text> ();
					tempoMuertes.begingCountdown = false;
					noRecargar.noPressR = true;
					if (timeWait > 0) {
						texto.enabled = true;
						timeWait -= Time.deltaTime;
						texto.text = "Get Ready for the Next Level! " + timeWait.ToString ("0");

					//Aqui hacemos el cambio de escenario
					}else if (timeWait <= 0) {
						timeWait = 0;
						texto.text = "Get Ready for the Next Level! " + timeWait.ToString ("0");
						pulsado = PulsarBoton ();
						if (pulsado) {
							vars.level = 6;
							tempoMuertes.timeLeft = vars.currentTime;
							texto.enabled = false;
							CargarNuevoNivel carga = GameObject.Find ("JuegoGeneral").GetComponent<CargarNuevoNivel> ();
							carga.cargar = false;
							noRecargar.noPressR = false;
							carga.Cargar (vars.level);
						}
					}
				}else if (n_cats < maxCatsKills && tempoMuertes.timeLeft > 0) {
					GameObject nextLevel = GameObject.Find ("Next Level");
					Text texto = nextLevel.GetComponent<Text> ();
					texto.enabled = false;
				}
			}else{
				if (!unaVez) {
					GameObject _player = GameObject.Find ("KornRak(Clone)");
					_disparo = true;
					unaVez = true;
					Destroy (_player);
					respawn_player.player--;
					respawn_player.respawnPlayer = false;
					ButtonReplayLevel_1 replay = GameObject.Find ("ReplayLevel_1").GetComponent<ButtonReplayLevel_1> ();
					replay.level = "Nivel_1_Normal";
					Camera camaraPatroll_1 = GameObject.Find ("PatrollCamera").GetComponent<Camera> ();
					Camera camaraPatroll_2 = GameObject.Find ("PatrollCamera_lvl2").GetComponent<Camera> ();
					camaraPatroll_1.enabled = true;
					camaraPatroll_2.enabled = false;
				}
			}

		}else if (vars.d_normal && vars.level == 6 && vars.street) {

			//Si no hay game over, se procesara el nivel
			if (!over.end) {
				//Le damos al jugador las coordenadas donde aparecer en el inicio del proximo nivel
				//Y lo respawneamos.
				if (!respawneado) {
					RespawnPlayer respawn_player = GameObject.Find ("RespawnPlayer").GetComponent<RespawnPlayer> ();
					respawn_player.posX = 152.51f; respawn_player.posY = -1.22f; respawn_player.posZ = -88.55f;
					respawn_player.rotateY = -90;
					respawn_player.respawnPlayer = true;
					tempoMuertes.timeLeft = vars.currentTime;
					unaVez = false;

					//Ademas, disponemos de la municion que tengamos en ese momento, tanto en la recamara como
					//en la interfaz y la añadimos a todos los controladores.
					GameObject shotgun = GameObject.Find ("Disparador");
					if (shotgun != null) {
						noRecargar = shotgun.GetComponent<Recargar> ();
						Disparar bloquearDisparo = shotgun.GetComponent<Disparar> ();
						if (bloquearDisparo.contador == 0) {
							contadorDisparos = 2;
							bloquearDisparo.contador = contadorDisparos;
							bloquearDisparo.anim.SetInteger ("Contador", contadorDisparos);
							respawneado = true;
						}else if (bloquearDisparo.contador == 1) {
							contadorDisparos = 1;
							bloquearDisparo.anim.SetInteger ("Contador", contadorDisparos);
							respawneado = true;
						}
					}
				}

				//Mostramos en pantalla los datos que tiene hasta el momento.
				GameObject puntos = GameObject.Find ("Puntos");
				Text _puntos = puntos.GetComponent<Text> ();
				_puntos.text = vars.puntos.ToString ();
				GameObject gatitos = GameObject.Find ("Kills");
				Text _gatitos = gatitos.GetComponent<Text> ();
				_gatitos.text = vars.n_cats.ToString ();
				GameObject balasDisponibles = GameObject.Find ("Bullets");
				Text _balas = balasDisponibles.GetComponent<Text> ();
				if (_balas.text == "")
					_balas.text = vars.n_balas.ToString ();

				//Limitamos el numero de gatitos a reventar y empezamos a descontar tiempo
				maxCatsKills = 130;
				CatKill objetivos = GameObject.Find ("Kills").GetComponent<CatKill> ();
				objetivos.Targets (maxCatsKills);
				tempoMuertes.begingCountdown = true;

				//Comporobamos, en todo momento, la cantidad de gatos muertos. Una vez que el tiempo
				//se agote, pasaremos de nivel o no.
				if (n_cats >= maxCatsKills && tempoMuertes.timeLeft >= 0) {
					GameObject nextLevel = GameObject.Find ("Next Level");
					Text texto = nextLevel.GetComponent<Text> ();
					tempoMuertes.begingCountdown = false;
					noRecargar.noPressR = true;
					if (timeWait > 0) {
						texto.enabled = true;
						timeWait -= Time.deltaTime;
						texto.text = "Get Ready for the Next Level! " + timeWait.ToString ("0");
						
						//Aqui hacemos el cambio de escenario
					}else if (timeWait <= 0) {
						timeWait = 0;
						texto.text = "Get Ready for the Next Level! " + timeWait.ToString ("0");
						pulsado = PulsarBoton ();
						if (pulsado) {
							vars.level = 9;
							tempoMuertes.timeLeft = vars.currentTime;
							texto.enabled = false;
							CargarNuevoNivel carga = GameObject.Find ("JuegoGeneral").GetComponent<CargarNuevoNivel> ();
							carga.cargar = false;
							noRecargar.noPressR = false;
							carga.Cargar (vars.level);
						}
					}
				}else if (n_cats < maxCatsKills && tempoMuertes.timeLeft > 0) {
					GameObject nextLevel = GameObject.Find ("Next Level");
					Text texto = nextLevel.GetComponent<Text> ();
					texto.enabled = false;
				}
			}else{
				if (!unaVez) {
					ButtonReplayLevel_2 replay = GameObject.Find ("ReplayLevel_2").GetComponent<ButtonReplayLevel_2> ();
					replay.level = "Nivel_1_Normal";
					GameObject _player = GameObject.Find ("KornRak(Clone)");
					Destroy (_player);
					respawn_player.player--;
					respawn_player.respawnPlayer = false;
					unaVez = true;
					camaraPatroll_1 = GameObject.Find ("PatrollCamera").GetComponent<Camera> ();
					camaraPatroll_2 = GameObject.Find ("PatrollCamera_lvl2").GetComponent<Camera> ();
					camaraPatroll_1.enabled = false;
					camaraPatroll_2.enabled = true;
				}else if (unaVez && vars.carga_completa)
					vars.level = 3;
			}
		}else if (vars.d_normal && vars.level == 9 && vars.street){

			//Si no hay game over, se procesara el nivel
			if (!over.end) {
				//Le damos al jugador las coordenadas donde aparecer en el inicio del proximo nivel
				//Y lo respawneamos
				if (!respawneado) {
					RespawnPlayer respawn_player = GameObject.Find ("RespawnPlayer").GetComponent<RespawnPlayer> ();

					//Con esta linea hacemos que el jugador comience el tercer nivel en la misma posicion con la que
					//acabo el segundo.
					respawn_player.posX = vars.posXPlayer; 
					respawn_player.posY = vars.posYPlayer; 
					respawn_player.posZ = vars.posZPlayer;
					respawn_player.rotateY = -90;
					respawn_player.respawnPlayer = true;
					tempoMuertes.timeLeft = vars.currentTime;
					unaVez = false;
					
					//Ademas, disponemos de la municion que tengamos en ese momento, tanto en la recamara como
					//en la interfaz y la añadimos a todos los controladores.
					GameObject shotgun = GameObject.Find ("Disparador");
					if (shotgun != null) {
						noRecargar = shotgun.GetComponent<Recargar> ();
						Disparar bloquearDisparo = shotgun.GetComponent<Disparar> ();
						if (bloquearDisparo.contador == 0) {
							contadorDisparos = 2;
							bloquearDisparo.contador = contadorDisparos;
							bloquearDisparo.anim.SetInteger ("Contador", contadorDisparos);
							respawneado = true;
						}else if (bloquearDisparo.contador == 1) {
							contadorDisparos = 1;
							bloquearDisparo.anim.SetInteger ("Contador", contadorDisparos);
							respawneado = true;
						}
					}
				}

				//Mostramos en pantalla los datos que tiene hasta el momento.
				GameObject puntos = GameObject.Find ("Puntos");
				Text _puntos = puntos.GetComponent<Text> ();
				_puntos.text = vars.puntos.ToString ();
				GameObject gatitos = GameObject.Find ("Kills");
				Text _gatitos = gatitos.GetComponent<Text> ();
				_gatitos.text = vars.n_cats.ToString ();
				GameObject balasDisponibles = GameObject.Find ("Bullets");
				Text _balas = balasDisponibles.GetComponent<Text> ();
				if (_balas.text == "")
					_balas.text = vars.n_balas.ToString ();
				
				//Limitamos el numero de gatitos a reventar y empezamos a descontar tiempo
				maxCatsKills = 195;
				CatKill objetivos = GameObject.Find ("Kills").GetComponent<CatKill> ();
				objetivos.Targets (maxCatsKills);
				tempoMuertes.begingCountdown = true;

				//Comporobamos, en todo momento, la cantidad de gatos muertos. Una vez que el tiempo
				//se agote, pasaremos de nivel o no.
				if (n_cats >= maxCatsKills && tempoMuertes.timeLeft >= 0) {
					GameObject nextLevel = GameObject.Find ("Next Level");
					Text texto = nextLevel.GetComponent<Text> ();
					noRecargar.noPressR = true;
					if (timeWait > 0) {
						texto.enabled = true;
						timeWait -= Time.deltaTime;
						texto.text = "VICTORY!! You Can Continue... ";
						
						//Aqui hacemos el cambio de escenario
					}else if (timeWait <= 0) {
						timeWait = 0;
						texto.text = "VICTORY!! You Can Continue... ";
						tempoMuertes.begingCountdown = false;
						pulsado = PulsarBoton ();
						if (pulsado) {
							vars.level = 12;
							texto.enabled = false;
							CargarNuevoNivel carga = GameObject.Find ("JuegoGeneral").GetComponent<CargarNuevoNivel> ();
							carga.cargar = false;
							noRecargar.noPressR = false;
							carga.Cargar (vars.level);
						}
					}
				}else if (n_cats < maxCatsKills && tempoMuertes.timeLeft > 0) {
					GameObject nextLevel = GameObject.Find ("Next Level");
					Text texto = nextLevel.GetComponent<Text> ();
					texto.enabled = false;
				}
			}else{
				if (!unaVez) {
					ButtonReplayLevel_3 replay = GameObject.Find ("ReplayLevel_3").GetComponent<ButtonReplayLevel_3> ();
					replay.level = "Nivel_1_Normal";
					GameObject _player = GameObject.Find ("KornRak(Clone)");
					Destroy (_player);
					respawn_player.player--;
					respawn_player.respawnPlayer = false;
					Camera camaraPatroll_1 = GameObject.Find ("PatrollCamera").GetComponent<Camera> ();
					Camera camaraPatroll_2 = GameObject.Find ("PatrollCamera_lvl2").GetComponent<Camera> ();
					Camera camaraPatroll_3 = GameObject.Find ("PatrollCamera_lvl3").GetComponent<Camera> ();
					camaraPatroll_1.enabled = false;
					camaraPatroll_2.enabled = false;
					camaraPatroll_3.enabled = true;
					unaVez = true;
				}else if (unaVez && vars.carga_completa)
					vars.level = 3;
			}
		}
	}

	//Con este metodo conseguimos esperar hasta que el jugador decida cambiar de nivel
	//...pulsando sobre el boton del mouse.
	bool PulsarBoton () {

		bool boton = false;
		GameObject mouseContinue = GameObject.Find ("Mouse Continue");
		Text textoButton = mouseContinue.GetComponent<Text> ();

		while (!Input.GetKeyDown (KeyCode.Mouse0)) {
			alpha_ = textoButton.color.a;
			textoButton.text = "Press Mouse Button for Continue";

			if (alpha_ > 0 && !bloqueo) {
				alpha_ -= speed * Time.deltaTime;
				textoButton.color = new Color (textoButton.color.r, textoButton.color.g, textoButton.color.b, alpha_);
			}else if (alpha_ <= 0 && !bloqueo)
				bloqueo = true;
			
			if (alpha_ < 1 && bloqueo) {
				alpha_ += speed * Time.deltaTime;
				textoButton.color = new Color (textoButton.color.r, textoButton.color.g, textoButton.color.b, alpha_);
			}else if (alpha_ >= 1 && bloqueo)
				bloqueo = false;

			return boton;
		}

		boton = Input.GetKeyDown (KeyCode.Mouse0);
		_disparo = true;
		GameObject _player = GameObject.Find ("KornRak(Clone)");
		Destroy (_player);
		respawn_player.player--;
		textoButton.enabled = false;
		return boton;
	}
}
