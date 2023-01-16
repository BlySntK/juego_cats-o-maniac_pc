using UnityEngine;
using System.Collections;

public class TirggerInicialBack : MonoBehaviour {
	
	Camera cam_1, cam_2, cam_3, cam_4, cam_5;
	public bool inicial;

	void OnTriggerEnter (Collider it) {

		if (it.gameObject.name == "KornRakMenu(Clone)") {
			cam_1 = GameObject.Find ("Camera_1_Trigger").GetComponent<Camera> ();
			cam_2 = GameObject.Find ("Camera_2_TriggerFollow").GetComponent<Camera> ();
			cam_3 = GameObject.Find ("Camera_3_TriggerFollowFoot").GetComponent<Camera> ();
			cam_4 = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			cam_5 = GameObject.Find ("CameraDifferent").GetComponent<Camera> ();
			
			cam_1.enabled = false;
			cam_2.enabled = false;
			cam_3.enabled = false;
			cam_4.enabled = true;
			cam_5.enabled = false;
			inicial = true;
		}
	}
}
