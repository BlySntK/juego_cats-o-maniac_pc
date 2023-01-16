using UnityEngine;
using System.Collections;

public class CamaraVigilancia_3 : MonoBehaviour {

	float posX = -98.2f;
	float posY = 12.52f;
	float posZ = 598.51f;


	void Start () {
		
		Camera cam = GetComponent<Camera> ();
		AudioListener audio = GetComponent<AudioListener> ();
		audio.enabled = false;
		cam.enabled = false;
		cam.transform.localPosition = new Vector3 (posX, posY, posZ);
	}
	
	void Update () {
		
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();

		//Dependera de la dificultad en la que nos encontremos...
		if (over.end && vars.level == 9 || vars.level == 10 || vars.level == 11) {
			Camera cam = GetComponent<Camera> ();
			AudioListener audio = GetComponent<AudioListener> ();
			cam.enabled = true;
			audio.enabled = true;
			
		}else{
			Camera cam = GetComponent<Camera> ();
			AudioListener audio = GetComponent<AudioListener> ();
			cam.enabled = false;
			audio.enabled = false;
		}
	}
}
