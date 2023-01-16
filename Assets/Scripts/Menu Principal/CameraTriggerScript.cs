using UnityEngine;
using System.Collections;

public class CameraTriggerScript : MonoBehaviour {

	Transform korn;
	Trigger1_Script trigger;
	bool activa;

	void Update () {

		trigger = GameObject.Find ("Trigger_1").GetComponent<Trigger1_Script>();
		activa = trigger.activar;
		if (activa) {
			korn = GameObject.Find ("KornRakMenu(Clone)").transform;
			transform.LookAt (korn);
		}
	}
}
