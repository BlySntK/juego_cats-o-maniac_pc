using UnityEngine;
using System.Collections;

public class CambiarWayPoint : MonoBehaviour {

	public Transform siguiente_way;


	void OnTriggerStay (Collider col) {

		if (col.gameObject.name == "Gatito(Clone)")
			col.GetComponent<Move>().seleccion = siguiente_way;
	}
}
