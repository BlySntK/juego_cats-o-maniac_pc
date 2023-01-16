using UnityEngine;
using System.Collections;

public class MoverAKornRak : MonoBehaviour {

	float speed = 0.55f;
	float gravity = 20;
	CharacterController caracter;
	public bool creditos;

	void Update () {
	
		if (creditos) {
			caracter = GetComponent<CharacterController>();
			Vector3 mover = new Vector3 (0, 0, speed);
			mover = transform.TransformDirection (mover);
			mover.y -= gravity;
			caracter.Move (mover * Time.deltaTime);
		}
	}
}
