using UnityEngine;
using System.Collections;

public class Destruir : MonoBehaviour {
	
	public GameObject sangre;
	Muerte mort;

	void Update () {

		mort = GetComponent<Muerte> ();
		if (mort.muerte) {
			Instantiate (sangre, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
