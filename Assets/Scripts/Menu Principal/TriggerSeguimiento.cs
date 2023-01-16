using UnityEngine;
using System.Collections;

public class TriggerSeguimiento : MonoBehaviour {

	public bool seguir;

	void OnTriggerEnter (Collider it) {

		if (it.gameObject.name == "KornRakMenu(Clone)") {
			Camera cam = GameObject.Find ("Camera_2_TriggerFollow").GetComponent<Camera> ();
			Camera cam_2 = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			cam.enabled = true;
			cam_2.enabled = false;
			seguir = true;
		}
	}
}
