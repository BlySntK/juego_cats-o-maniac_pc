using UnityEngine;
using System.Collections;

public class SeguirBrevemente : MonoBehaviour {

	Transform korn;
	TriggerSeguimiento triggerFollow;
	bool seguir;

	void Update () {

		triggerFollow = GameObject.Find ("TriggerFollow").GetComponent<TriggerSeguimiento> ();
		seguir = triggerFollow.seguir;

		if (seguir) {
			korn = GameObject.Find ("KornRakMenu(Clone)").transform;
			transform.position = new Vector3 (korn.position.x + 2, korn.position.y + 1, korn.position.z);
		}
	}
}
