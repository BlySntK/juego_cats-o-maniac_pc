using UnityEngine;
using System.Collections;

public class PuntosA0 : MonoBehaviour {

	Score puntos;
	CatKill kills;
	ContadorBalas contBalas; //Lo que se muestra en la interfaz
	Disparar _balas;
	int p = 0;
	int cats = 0;
	int balas = 2; //Las balas disponibles al principio
	bool unaSolaVez;


	void Awake () {

		puntos = GameObject.Find ("Puntos").GetComponent<Score> ();
		kills = GameObject.Find ("Kills").GetComponent<CatKill> ();
		contBalas = GameObject.Find ("Bullets").GetComponent<ContadorBalas> ();
		kills.Contador (cats);
		puntos.Puntuar (p);
	}

	void Update () {

		RespawnPlayer player = GameObject.Find ("RespawnPlayer").GetComponent<RespawnPlayer> ();
		if (player.player == 1 && !unaSolaVez) {
			_balas = GameObject.Find ("Disparador").GetComponent<Disparar> ();
			_balas.contador_ui = balas;
			contBalas.Contar (balas);
			unaSolaVez = true;
		}
	}
}
