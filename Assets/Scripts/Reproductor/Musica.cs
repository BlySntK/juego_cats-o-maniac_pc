using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Musica : MonoBehaviour {

	public AudioClip[] audio; //Lista de canciones
	public AudioClip sadSong; //Cancion triste
	Cancion soloUnaCancion;


	void Update () {

		float numero = Random.Range (0, 4);
		soloUnaCancion = GameObject.Find ("Reproductor").GetComponent<Cancion> ();
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		if (!over.end) {
			if (!soloUnaCancion.nuevaCancion) {
				VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
				if (vars.level == 3 || vars.level == 4 || vars.level == 5) {
					if (numero == 0) {
						if (!soloUnaCancion._song.isPlaying) {
							soloUnaCancion._song.clip = audio[1];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion._song.Play ();
						}
					}
					if (numero == 1) {
						if (!soloUnaCancion._song.isPlaying) {
							soloUnaCancion._song.clip = audio[0];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion._song.Play ();
						}
					}
					if (numero == 2) {
						if (!soloUnaCancion._song.isPlaying) {
							soloUnaCancion._song.clip = audio[3];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion._song.Play ();
						}
					}
					if (numero == 3) {
						if (!soloUnaCancion._song.isPlaying) {
							soloUnaCancion._song.clip = audio[2];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion._song.Play ();
						}
					}
				}else if (vars.level == 6 || vars.level == 7 || vars.level == 8) {
					if (numero == 0) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[1];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
					if (numero == 1) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[0];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
					if (numero == 2) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[3];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
					if (numero == 3) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[2];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
				}else if (vars.level == 9 || vars.level == 10 || vars.level == 11) {
					if (numero == 0) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[1];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
					if (numero == 1) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[0];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
					if (numero == 2) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[3];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
					if (numero == 3) {
						if (!soloUnaCancion.__song.isPlaying) {
							soloUnaCancion.__song.clip = audio[2];
							soloUnaCancion.nuevaCancion = true;
							soloUnaCancion.__song.Play ();
						}
					}
				}
			}
		}else{
			VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
			if (vars.level == 3 || vars.level == 4 || vars.level == 5) {
				if (!soloUnaCancion.nuevaCancion) {
					soloUnaCancion._song.clip = sadSong;
					soloUnaCancion._song.Play ();
					soloUnaCancion._song.loop = true;
					soloUnaCancion.nuevaCancion = true;
				}
			}else if (vars.level == 6 || vars.level == 7 || vars.level == 8) {
				if (!soloUnaCancion.nuevaCancion) {
					soloUnaCancion.__song.clip = sadSong;
					soloUnaCancion.__song.Play ();
					soloUnaCancion.__song.loop = true;
					soloUnaCancion.nuevaCancion = true;
				}
			}else if (vars.level == 9 || vars.level == 10 || vars.level == 11) {
				if (!soloUnaCancion.nuevaCancion) {
					soloUnaCancion.__song.clip = sadSong;
					soloUnaCancion.__song.Play ();
					soloUnaCancion.__song.loop = true;
					soloUnaCancion.nuevaCancion = true;
				}
			}
		}
	}
}
