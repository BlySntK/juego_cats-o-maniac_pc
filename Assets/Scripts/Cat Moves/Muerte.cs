using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour {

	public bool muerte; //Variable de la que depende el objeto Destruir
	CatKill cat;
	Temporizador sumarSeg;
	Score puntos;
	ScoreTotal totalPuntos; //Variable general de puntos, es la que se mostrara en la interfaz
	int n_puntos;
	HardLevels reintentar;
	NormalLevels _reintentar;
	EasyLevels reintentar_;


	void OnTriggerEnter (Collider col) {

		if (col.gameObject.tag == "Bala") {
			VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
			RespawnCats reponer = GameObject.Find ("Gatitos").GetComponent<RespawnCats>();
			SonidoMuerte sonido = reponer.GetComponent<SonidoMuerte> ();
			SonidoSplash sonido_ = GameObject.Find ("SplashCats").GetComponent<SonidoSplash> ();
			cat = GameObject.Find ("Kills").GetComponent<CatKill> ();
			puntos = GameObject.Find ("Puntos").GetComponent<Score> ();
			totalPuntos = GameObject.Find ("Gatitos").GetComponent<ScoreTotal> ();
			sumarSeg = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			reponer.descuento--;
			reponer.currentCat--;

			//Controlamos la cantidad de gatitos muertos y los mostramos en la interfaz
			if (vars.level > 5 && vars.level < 12) {
				if (reponer.contador == 0) {
					reponer.contador = vars.n_cats;
					reponer.contador++;
				}else
					reponer.contador++;
			}else if (vars.level > 2 && vars.level < 6)
				reponer.contador++;

			cat.Contador (reponer.contador);

			//Aqui establecemos los puntos por gatito reventado
			if (vars.level > 5 && vars.level < 12 && vars.puntos > 0) {
				n_puntos = 15;
				if (totalPuntos.totalScore == 0) {
					totalPuntos.totalScore = vars.puntos;
					totalPuntos.totalScore += n_puntos;
				}else if (totalPuntos.totalScore > 0)
					totalPuntos.totalScore += n_puntos;
			}else if (vars.level > 2 && vars.level < 6) {
				n_puntos = 15;
				totalPuntos.totalScore += n_puntos;
			}
			puntos.Puntuar (totalPuntos.totalScore);

			//Los distintos "Bonus Time" por matar un gatito:
			/* NORMAL */
			if (vars.level == 3 && vars.d_normal)
				sumarSeg.timeLeft += 3;
			else if (vars.level == 6 && vars.d_normal)
				sumarSeg.timeLeft += 2;
			else if (vars.level == 9 && vars.d_normal)
				sumarSeg.timeLeft += 1;

			/* PUBER (FACIL) */
			if (vars.level == 4 && vars.d_easy)
				sumarSeg.timeLeft += 5;
			else if (vars.level == 7 && vars.d_easy)
				sumarSeg.timeLeft += 5;
			else if (vars.level == 10 && vars.d_easy)
				sumarSeg.timeLeft += 5;

			/* JODIDO */
			if (vars.level == 5 && vars.d_hard)
				sumarSeg.timeLeft += 1;
			else if (vars.level == 8 && vars.d_hard)
				sumarSeg.timeLeft -= 4;
			else if (vars.level == 11 && vars.d_hard)
				sumarSeg.timeLeft += 2;

			muerte = true;
			sonido.muerte = muerte;
			sonido_.muerte = muerte;
			Destroy (col.gameObject);
		}
	}

	void Update () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		Temporizador tempo = GameObject.Find ("Timer").GetComponent<Temporizador> ();
		//Depende de la dificultad:
		if (vars.d_hard) {
			reintentar = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();

			if (vars.level == 5 && reintentar.n_cats < reintentar.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 8 && reintentar.n_cats < reintentar.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 11 && reintentar.n_cats < reintentar.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 5 && reintentar.n_cats >= reintentar.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
			else if (vars.level == 8 && reintentar.n_cats >= reintentar.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
			else if (vars.level == 11 && reintentar.n_cats >= reintentar.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
		}else if (vars.d_easy) {
			reintentar_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();

			if (vars.level == 4 && reintentar_.n_cats < reintentar_.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 7 && reintentar_.n_cats < reintentar_.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 10 && reintentar_.n_cats < reintentar_.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 4 && reintentar_.n_cats >= reintentar_.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
			else if (vars.level == 7 && reintentar_.n_cats >= reintentar_.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
			else if (vars.level == 10 && reintentar_.n_cats >= reintentar_.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
		}else if (vars.d_normal) {
			_reintentar = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();

			if (vars.level == 3 && _reintentar.n_cats < _reintentar.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 6 && _reintentar.n_cats < _reintentar.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 9 && _reintentar.n_cats < _reintentar.maxCatsKills && tempo.timeLeft <= 0)
				Destroy (gameObject);
			else if (vars.level == 3 && _reintentar.n_cats >= _reintentar.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
			else if (vars.level == 6 && _reintentar.n_cats >= _reintentar.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
			else if (vars.level == 9 && _reintentar.n_cats >= _reintentar.maxCatsKills && tempo.timeLeft >= 0)
				Destroy (gameObject);
		}
	}
}
