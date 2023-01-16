using UnityEngine;
using System.Collections;

public class TriggerFollowFoots : MonoBehaviour {

	public bool seguir;
	
	void OnTriggerEnter (Collider it) {
		
		if (it.gameObject.name == "KornRakMenu(Clone)") {
			Camera cam = GameObject.Find ("Camera_2_TriggerFollow").GetComponent<Camera> ();
			Camera cam_2 = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			Camera cam_3 = GameObject.Find ("Camera_3_TriggerFollowFoot").GetComponent<Camera>();
			cam.enabled = false;
			cam_2.enabled = false;
			cam_3.enabled = true;
			seguir = true;
		}
	}
}
