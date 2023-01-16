using UnityEngine;
using System.Collections;

public class VigilanciaFinal : MonoBehaviour {

	float speedCam = 0.08f;
	float rotateYmin = 107.29f;
	float rotateYmax = 163;
	bool turn;



	void Start () {

		Camera cam = GetComponent<Camera> ();
		AudioListener audio = GetComponent<AudioListener> ();
		audio.enabled = false;
		cam.enabled = false;
	}

	void Update () {

		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();

		//Dependera del nivel de dificultad en que nos encontremos...
		if (over.end && vars.level == 3 || vars.level == 4 || vars.level == 5) {
			Camera cam = GetComponent<Camera> ();
			AudioListener audio = GetComponent<AudioListener> ();
			cam.enabled = true;
			audio.enabled = true;

			if (cam.transform.eulerAngles.y < rotateYmax && !turn) {
				cam.transform.Rotate (new Vector3 (0, speedCam, 0));
			}else if (cam.transform.eulerAngles.y >= rotateYmax && !turn)
				turn = true;
			else if (cam.transform.eulerAngles.y > rotateYmin && turn)
				cam.transform.Rotate (new Vector3 (0, -speedCam, 0));
			else if (cam.transform.eulerAngles.y <= rotateYmin && turn)
				turn = false;

		}else{
			Camera cam = GetComponent<Camera> ();
			AudioListener audio = GetComponent<AudioListener> ();
			cam.enabled = false;
			audio.enabled = false;
		}
	}
}
