using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Comenzar : MonoBehaviour {
	
	InicioGeneral iniciar;
	AudioSource _clip;
	Animator andar;
	Camera parado, caminar;
	MoverAKornRak mover;
	public bool cambiarCancion;

	public void Creditos () {

		iniciar = GameObject.Find ("Posicion Inicial").GetComponent<InicioGeneral> ();
		_clip = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		andar = GameObject.Find ("KornRakMenu(Clone)").GetComponent<Animator> ();
		parado = GameObject.Find ("CameraMenu").GetComponent<Camera> ();
		caminar = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		mover = GameObject.Find ("KornRakMenu(Clone)").GetComponent<MoverAKornRak> ();
		iniciar.creditos.arriba = true;
		iniciar._jugar.enabled = true;
		iniciar._comenzar.enabled = false;
		andar.SetBool ("Caminar", true);
		cambiarCancion = true;
		mover.creditos = true;
		parado.enabled = false;
		caminar.enabled = true;
	}
}
