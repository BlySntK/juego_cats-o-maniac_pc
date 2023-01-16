using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InicioGeneral : MonoBehaviour {

	[HideInInspector]
	public Credits_Init creditos;
	Comenzar otraCancion;
	GameObject jugar, comenzar;
	[HideInInspector]
	public Image _jugar, _comenzar;
	public AudioClip clip, clip_2;
	[HideInInspector]
	public AudioSource clip_;
	bool cambiarCancion;

	void Start () {
		
		//Iniciamos el titulo de Menu Principal (no es aun comienzo del juego)
		//Iniciamos la musica del menu
		Canvas eleccion = GameObject.Find ("Canvas Eleccion").GetComponent<Canvas> ();
		Canvas titulo = GameObject.Find ("Canvas Titulo").GetComponent<Canvas> ();
		creditos = GameObject.Find ("Creditos").GetComponent<Credits_Init> ();
		clip_ = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		otraCancion = GameObject.Find ("Comenzar").GetComponent<Comenzar> ();
		clip_.clip = clip;
		clip_.Play ();
		clip_.loop = true;
		jugar = GameObject.Find ("Jugar");
		comenzar = GameObject.Find ("Comenzar");
		_jugar = jugar.GetComponent<Image> ();
		_comenzar = comenzar.GetComponent<Image> ();
		_jugar.enabled = false;
		_comenzar.enabled = true;
		eleccion.enabled = false;
		titulo.enabled = true;
	}

	void Update () {

		//Una vez demos a Comenzar, iniciaremos los creditos y cambiaremos a otra
		//pieza musical. Aqui podremos darle a jugar (En script Jugar)
		if (otraCancion.cambiarCancion && clip_.isPlaying) {
			clip_.volume -= 0.8f * Time.deltaTime;

			if (clip_.volume <= 0) {
				clip_.Stop ();
				otraCancion.cambiarCancion = false;
				cambiarCancion = true;
			}
		}

		if (cambiarCancion) {
			clip_.clip = clip_2;
			clip_.loop = true;
			if (cambiarCancion) {
				clip_.Play ();
				cambiarCancion = false;
			}
		}else if (!cambiarCancion && !otraCancion.cambiarCancion)
			clip_.volume += 0.8f * Time.deltaTime;
	}
}
