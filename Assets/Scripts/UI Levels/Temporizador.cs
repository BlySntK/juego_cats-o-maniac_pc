using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Temporizador : MonoBehaviour {

	[HideInInspector]
	public float timeLeft;
	public bool begingCountdown;
	GameObject timer;
	VariablesGlobales tiempoActual;
	string reloj;


	void Update () {

		timer = this.gameObject;
		tiempoActual = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		Text texto = timer.GetComponent<Text> ();
		GameObject labelTime = GameObject.Find ("TIME RELEASE");
		Image _labelTime = labelTime.GetComponent<Image> ();

		//Mientras el tiempo cuente...
		if (begingCountdown) {
			//Aparecera por pantalla
			_labelTime.enabled = true;
			texto.enabled = true;

			//El temporizador descontara hasta llegar a 0
			Opciones pausar = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
			if (!pausar.pausa) {
				if (timeLeft > 0) {
					timeLeft -= Time.deltaTime/2;
					int minutos = (int) timeLeft / 60;
					int segundos = (int) timeLeft % 60;
					reloj = string.Format ("{0:0}:{1:00}", minutos, segundos);
					texto.text = reloj;
					tiempoActual.currentTime = timeLeft;
				}else{
					//Una vez cumplido el tiempo, desaparecera del interfaz todo
					texto.enabled = false;
					_labelTime.enabled = false;
				}
			}
		}else{
			//Si hacemos que el tiempo deje de contar, tambien se ocultara todo
			//y se mantendra para el proximo nivel
			texto.enabled = false;
			_labelTime.enabled = false;
		}
	}
}
