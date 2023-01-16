using UnityEngine;
using System.Collections;

public class Trigger1_Script : MonoBehaviour {
	
	public bool activar;

	void OnTriggerEnter (Collider it) {

		if (it.gameObject.name == "KornRakMenu(Clone)") {
			Camera cam = GameObject.Find ("Camera_1_Trigger").GetComponent<Camera>();
			Camera cam_2 = GameObject.Find ("Camera_2_TriggerFollow").GetComponent<Camera>();
			Camera cam_3 = GameObject.Find ("Camera_3_TriggerFollowFoot").GetComponent<Camera> ();
			cam.enabled = true;
			cam_2.enabled = false;
			cam_3.enabled = false;
			activar = true;
		}
	}
}
