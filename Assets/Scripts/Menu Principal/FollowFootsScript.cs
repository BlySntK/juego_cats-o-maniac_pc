using UnityEngine;
using System.Collections;

public class FollowFootsScript : MonoBehaviour {

	Transform korn;
	TriggerSeguimiento triggerFollow;
	bool seguir;
	
	void Update () {
		
		triggerFollow = GameObject.Find ("TriggerFollow").GetComponent<TriggerSeguimiento> ();
		seguir = triggerFollow.seguir;
		
		if (seguir) {
			korn = GameObject.Find ("KornRakMenu(Clone)").transform;
			transform.position = new Vector3 (korn.position.x + 0.5f, korn.position.y + 0.1f, korn.position.z + 0.3f);
		}
	}
}
