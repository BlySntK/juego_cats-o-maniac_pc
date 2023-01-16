using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarLife : MonoBehaviour {

	public GameObject car, explosion;
	public float resistencia = 10;
	float alpha, timeOff;
	public AudioClip explo;
	public Canvas car_canvas;

	void OnTriggerEnter (Collider it) {

		if (it.gameObject.name == "Bala(Clone)") {
			if (resistencia > 0)
				resistencia--;
			else{
				Instantiate (car, transform.position, transform.rotation);
				Instantiate (explosion, transform.position, transform.rotation);
				Camera camKornRak = GameObject.FindWithTag ("CamKornRak").GetComponent<Camera> ();
				AudioSource audioExplo = camKornRak.GetComponent<AudioSource> ();
				audioExplo.clip = explo;
				audioExplo.Play ();
				Destroy (gameObject);
			}
		}

		if (it.gameObject.name == "KornRak(Clone)") {
			GameObject canvas_car = GameObject.Find ("Canvas Car");
			car_canvas = canvas_car.GetComponent<Canvas> ();
			car_canvas.enabled = true;
			timeOff = 6;
		}
	}

	void OnTriggerExit (Collider it) {

		if (it.gameObject.name == "KornRak(Clone)") {
			GameObject canvas_car = GameObject.Find ("Canvas Car");
			car_canvas = canvas_car.GetComponent<Canvas> ();
			car_canvas.enabled = false;
		}
	}

	void Update () {

		if (timeOff > 0 && car_canvas.enabled)
			timeOff -= Time.deltaTime;
		else if (timeOff <= 0 && car_canvas.enabled) {
			Image car_text = GameObject.Find ("PerfectCarText").GetComponent<Image> ();
			if (car_text.color.a > 0) {
				alpha -= Time.deltaTime;
				car_text.color = new Color (car_text.color.r, car_text.color.g, car_text.color.b, alpha);
			}else
				car_canvas.enabled = false;
		}
	}
}
