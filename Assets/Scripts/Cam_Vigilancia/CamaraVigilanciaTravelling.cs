using UnityEngine;
using System.Collections;

public class CamaraVigilanciaTravelling : MonoBehaviour {

	float speedCam = 2;
	float translateXmin = -74.27f;
	float translateXmax = -101.36f;
	float posY = 1.5f;
	float posZ = 620.58f;
	bool turn;
	
	
	
	void Start () {
		
		Camera cam = GetComponent<Camera> ();
		AudioListener audio = GetComponent<AudioListener> ();
		audio.enabled = false;
		cam.enabled = false;
		cam.transform.localPosition = new Vector3 (translateXmin, posY, posZ);
	}
	
	void Update () {
		
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();

		//Dependera de la dificultad en la que nos encontremos...
		if (over.end && vars.level == 6 || vars.level == 7 || vars.level == 8) {
			Camera cam = GetComponent<Camera> ();
			AudioListener audio = GetComponent<AudioListener> ();
			cam.enabled = true;
			audio.enabled = true;
			
			if (cam.transform.localPosition.x > translateXmax && !turn) {
				cam.transform.Translate (new Vector3 (-speedCam * Time.deltaTime, 0, 0));
			}else if (cam.transform.localPosition.x <= translateXmax && !turn)
				turn = true;
			else if (cam.transform.localPosition.x < translateXmin && turn)
				cam.transform.Translate (new Vector3 (speedCam * Time.deltaTime, 0, 0));
			else if (cam.transform.localPosition.x >= translateXmin && turn)
				turn = false;
			
		}else{
			Camera cam = GetComponent<Camera> ();
			AudioListener audio = GetComponent<AudioListener> ();
			cam.enabled = false;
			audio.enabled = false;
		}
	}
}
